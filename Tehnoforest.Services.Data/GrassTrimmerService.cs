namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Services.Data.Models.GardenTractor;
    using Tehnoforest.Services.Data.Models.GrassTrimmer;
    using Tehnoforest.Web.ViewModels.Enums;

    using Tehnoforest.Web.ViewModels.GrassTrimer;
    using Tehnoforest.Web.ViewModels.GrassTrimmer;

    public class GrassTrimmerService : IGrassTrimmerService
    {
        private readonly TehnoforestDbContext dbContext;

        public GrassTrimmerService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllGrassTrimmersFilteredAndPagedServiceModel> AllAsync(AllGrassTrimmersQueryModel queryModel)
        {
            IQueryable<GrassTrimmer> grassTrimmersQuery = this.dbContext
              .GrassTrimmers
              .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                grassTrimmersQuery = grassTrimmersQuery
                    .Where(h => EF.Functions.Like(h.Model, wildCard) ||
                    EF.Functions.Like(h.Description, wildCard));
            }

            grassTrimmersQuery = queryModel.GrassTrimmerSorting switch
            {
                ProductsSorting.NameAZ => grassTrimmersQuery
                .OrderBy(c => c.Model),
                ProductsSorting.NameZA => grassTrimmersQuery
                .OrderByDescending(h => h.Model),
                ProductsSorting.PriceAscending => grassTrimmersQuery
                .OrderBy(c => c.Price),
                ProductsSorting.PriceDescending => grassTrimmersQuery
                .OrderByDescending(c => c.Price)
            };

            IEnumerable<GrassTrimmerAllViewModel> allGrassTrimmers = await grassTrimmersQuery
                .Where(gt => gt.IsAvailable)
                .Skip((queryModel.CurrentPage - 1) * queryModel.GrassTrimmerPerPage)
                .Take(queryModel.GrassTrimmerPerPage)
                .Select(gt => new GrassTrimmerAllViewModel()
                {
                    Id = gt.Id,
                    Model = gt.Model,
                    Power = gt.Power,
                    CuttingWidth = gt.CuttingWidth,
                    ImageUrl = gt.ImageUrl,
                    Price = gt.Price
                })
                .ToArrayAsync();

            int totalGrasstrimmers = grassTrimmersQuery.Count();

            return new AllGrassTrimmersFilteredAndPagedServiceModel()
            {
                TotalGrassTrimmersCount = totalGrasstrimmers,
                GrassTrimmers = allGrassTrimmers
            };
        }

        public async Task<string> CreateAndReturnIdAsync(GrassTrimmerFormModel formModel)
        {
            GrassTrimmer newGrassTrimmer = new GrassTrimmer()
            {
                Model = formModel.Model,
                Power = formModel.Power,
                CuttingWidth = formModel.CuttingWidth,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.Price,
                Availability = formModel.Availability
            };

            await this.dbContext.GrassTrimmers.AddAsync(newGrassTrimmer);
            await this.dbContext.SaveChangesAsync();

            return newGrassTrimmer.Id.ToString();
        }

        public async Task<bool> ExistByModelAsync(string automowerModel)
        {
            bool result = await this.dbContext
                .GrassTrimmers
                .Where(gt => gt.IsAvailable)
                .AnyAsync(gt => gt.Model == automowerModel);

            return result;
        }
    }
}
