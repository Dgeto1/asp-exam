namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Services.Data.Models.LawnMower;
    using Tehnoforest.Web.ViewModels.Enums;
    using Tehnoforest.Web.ViewModels.LawnMower;

    public class LawnMowerService : ILawnMowerService
    {
        private readonly TehnoforestDbContext dbContext;

        public LawnMowerService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<AllLawnMowersFilteredAndPagedServiceModel> AllAsync(AllLawnMowersQueryModel queryModel)
        {
            IQueryable<LawnMower> lawnMowersQuery = this.dbContext
               .LawnMowers
               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                lawnMowersQuery = lawnMowersQuery
                    .Where(h => EF.Functions.Like(h.Model, wildCard) ||
                    EF.Functions.Like(h.Description, wildCard));
            }

            lawnMowersQuery = queryModel.LawnMowerSorting switch
            {
                ProductsSorting.NameAZ => lawnMowersQuery
                .OrderBy(c => c.Model),
                ProductsSorting.NameZA => lawnMowersQuery
                .OrderByDescending(h => h.Model),
                ProductsSorting.PriceAscending => lawnMowersQuery
                .OrderBy(c => c.Price),
                ProductsSorting.PriceDescending => lawnMowersQuery
                .OrderByDescending(c => c.Price)
            };

            IEnumerable<LawnMowerAllViewModel> allLawnMowers = await lawnMowersQuery
                .Where(a => a.IsAvailable)
                .Skip((queryModel.CurrentPage - 1) * queryModel.LawnMowerPerPage)
                .Take(queryModel.LawnMowerPerPage)
                .Select(a => new LawnMowerAllViewModel()
                {
                    Id = a.Id,
                    Model = a.Model,
                    WorkingAreaCapacity = a.WorkingAreaCapacity,
                    DriveSystem = a.DriveSystem,
                    ImageUrl = a.ImageUrl,
                    Price = a.Price
                })
                .ToArrayAsync();

            int totalLawnMowers = lawnMowersQuery.Count();

            return new AllLawnMowersFilteredAndPagedServiceModel()
            {
                TotalLawnMowersCount = totalLawnMowers,
                LawnMowers = allLawnMowers
            };
        }

        public async Task<string> CreateAndReturnIdAsync(LawnMowerFormModel formModel)
        {
            LawnMower newLawnMower = new LawnMower()
            {
                Model = formModel.Model,
                WorkingAreaCapacity = formModel.WorkingAreaCapacity,
                DriveSystem = formModel.DriveSystem,
                CuttingWidth = formModel.CuttingWidth,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.Price,
                Availability = formModel.Availability
            };

            await this.dbContext.LawnMowers.AddAsync(newLawnMower);
            await this.dbContext.SaveChangesAsync();

            return newLawnMower.Id.ToString();
        }

        public async Task DeleteLawnMowerByIdAsync(int lawnMowerId)
        {
            LawnMower lawnMower = await this.dbContext
           .LawnMowers
              .Where(a => a.IsAvailable)
              .FirstAsync(a => a.Id == lawnMowerId);

            lawnMower.IsAvailable = false;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditLawnMowerByIdAndFormModelAsync(int lawnMowerId, LawnMowerFormModel formModel)
        {
            LawnMower lawnMower = await this.dbContext
            .LawnMowers
               .Where(a => a.IsAvailable)
               .FirstAsync(a => a.Id == lawnMowerId);

            lawnMower.Model = formModel.Model;
            lawnMower.WorkingAreaCapacity = formModel.WorkingAreaCapacity;
            lawnMower.DriveSystem = formModel.DriveSystem;
            lawnMower.CuttingWidth = formModel.CuttingWidth;
            lawnMower.Description = formModel.Description;
            lawnMower.ImageUrl = formModel.ImageUrl;
            lawnMower.Price = formModel.Price;
            lawnMower.Availability = formModel.Availability;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistByModelAsync(string lawnMowerModel)
        {
            bool result = await this.dbContext
                .LawnMowers
                .Where(a => a.IsAvailable)
                .AnyAsync(a => a.Model == lawnMowerModel);

            return result;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
               .LawnMowers
               .Where(a => a.IsAvailable)
               .AnyAsync(a => a.Id == id);

            return result;
        }

        public async Task<LawnMowerDetailsViewModel> GetDetailsByIdAsync(int lawnMowerId)
        {
            LawnMower lawnMower = await this.dbContext
            .LawnMowers
                .Where(a => a.IsAvailable)
                .FirstAsync(a => a.Id == lawnMowerId);

            return new LawnMowerDetailsViewModel()
            {
                Id = lawnMower.Id,
                Model = lawnMower.Model,
                WorkingAreaCapacity = lawnMower.WorkingAreaCapacity,
                DriveSystem = lawnMower.DriveSystem,
                CuttingWidth = lawnMower.CuttingWidth,
                Description = lawnMower.Description,
                ImageUrl = lawnMower.ImageUrl,
                Price = lawnMower.Price
            };
        }

        public async Task<LawnMowerDeleteViewModel> GetLawnMowerForDeleteByIdAsync(int lawnMowerId)
        {
            LawnMower lawnMower = await this.dbContext
            .LawnMowers
                .Where(a => a.IsAvailable)
                .FirstAsync(a => a.Id == lawnMowerId);

            return new LawnMowerDeleteViewModel()
            {
                Model = lawnMower.Model,
                Availability = lawnMower.Availability,
                ImageUrl = lawnMower.ImageUrl
            };
        }

        public async Task<LawnMowerFormModel> GetLawnMowerForEditByIdAsync(int lawnMowerId)
        {
            LawnMower lawnMower = await this.dbContext
            .LawnMowers
                .Where(a => a.IsAvailable)
                .FirstAsync(a => a.Id == lawnMowerId);

            return new LawnMowerFormModel
            {
                Model = lawnMower.Model,
                WorkingAreaCapacity = lawnMower.WorkingAreaCapacity,
                DriveSystem = lawnMower.DriveSystem,
                CuttingWidth = lawnMower.CuttingWidth,
                Description = lawnMower.Description,
                ImageUrl = lawnMower.ImageUrl,
                Price = lawnMower.Price,
                Availability = lawnMower.Availability
            };
        }
    }
}
