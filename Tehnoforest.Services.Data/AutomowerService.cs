namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Services.Data.Models.Automower;
    using Tehnoforest.Services.Data.Models.Chainsaw;
    using Tehnoforest.Web.ViewModels.Automower;
    using Tehnoforest.Web.ViewModels.Chainsaw;
    using Tehnoforest.Web.ViewModels.Enums;

    public class AutomowerService : IAutomowerService
    {
        private readonly TehnoforestDbContext dbContext;

        public AutomowerService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllAutomowersFilteredAndPagedServiceModel> AllAsync(AllAutomowersQueryModel queryModel)
        {
            IQueryable<Automower> automowersQuery = this.dbContext
                .Automowers
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                automowersQuery = automowersQuery
                    .Where(h => EF.Functions.Like(h.Model, wildCard) ||
                    EF.Functions.Like(h.Description, wildCard));
            }

            automowersQuery = queryModel.AutomowerSorting switch
            {
                ProductsSorting.NameAZ => automowersQuery
                .OrderBy(c => c.Model),
                ProductsSorting.NameZA => automowersQuery
                .OrderByDescending(h => h.Model),
                ProductsSorting.PriceAscending => automowersQuery
                .OrderBy(c => c.Price),
                ProductsSorting.PriceDescending => automowersQuery
                .OrderByDescending(c => c.Price)
            };

            IEnumerable<AutomowerAllViewModel> allAutomowers = await automowersQuery
                .Where(a => a.IsAvailable)
                .Skip((queryModel.CurrentPage - 1) * queryModel.AutomowerPerPage)
                .Take(queryModel.AutomowerPerPage)
                .Select(a => new AutomowerAllViewModel()
                {
                    Id = a.Id,
                    Model = a.Model,
                    WorkingAreaCapacity = a.WorkingAreaCapacity,
                    MaximumSlopePerformance = a.MaximumSlopePerformance,
                    ImageUrl = a.ImageUrl,
                    Price = a.Price
                })
                .ToArrayAsync();

            int totalAutomowers = automowersQuery.Count();

            return new AllAutomowersFilteredAndPagedServiceModel()
            {
                TotalAutomowersCount = totalAutomowers,
                Automowers = allAutomowers
            };
        }

        public async Task<string> CreateAndReturnIdAsync(AutomowerFormModel formModel)
        {
            Automower newAutomower = new Automower()
            {
                Model = formModel.Model,
                WorkingAreaCapacity = formModel.WorkingAreaCapacity,
                MaximumSlopePerformance = formModel.SlopePerformance,
                BoundaryType = formModel.BoundaryType,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.Price,
                Availability = formModel.Availability
            };

            await this.dbContext.Automowers.AddAsync(newAutomower);
            await this.dbContext.SaveChangesAsync();

            return newAutomower.Id.ToString();
        }

        public async Task<bool> ExistByModelAsync(string automowerModel)
        {
            bool result = await this.dbContext
                .Automowers
                .AnyAsync(a => a.Model == automowerModel);

            return result;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Automowers
                .AnyAsync(a => a.Id == id);

            return result;
        }
    }
}
