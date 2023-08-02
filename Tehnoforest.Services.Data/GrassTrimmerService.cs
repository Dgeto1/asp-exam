namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Services.Data.Models.GardenTractor;
    using Tehnoforest.Services.Data.Models.GrassTrimmer;
    using Tehnoforest.Web.ViewModels.Automower;
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
            IQueryable<Product> grassTrimmersQuery = this.dbContext
              .Products
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
                .Where(gt => gt.Power != null)
                .Where(gt => gt.CuttingWidth != null)
                .Skip((queryModel.CurrentPage - 1) * queryModel.GrassTrimmerPerPage)
                .Take(queryModel.GrassTrimmerPerPage)
                .Select(gt => new GrassTrimmerAllViewModel()
                {
                    Id = gt.Id,
                    Model = gt.Model,
                    Power = (int)gt.Power,
                    CuttingWidth = (int)gt.CuttingWidth,
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
            Product newGrassTrimmer = new Product()
            {
                Model = formModel.Model,
                Power = formModel.Power,
                CuttingWidth = formModel.CuttingWidth,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.Price,
                Availability = formModel.Availability
            };

            await this.dbContext.Products.AddAsync(newGrassTrimmer);
            await this.dbContext.SaveChangesAsync();

            return newGrassTrimmer.Id.ToString();
        }

        public async Task DeleteGrassTrimmerByIdAsync(int grassTrimmerId)
        {
            Product grassTrimmer = await this.dbContext
                .Products
                .Where(gt => gt.IsAvailable)
                .FirstAsync(gt => gt.Id == grassTrimmerId);

            grassTrimmer.IsAvailable = false;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditGrassTrimmerByIdAndFormModelAsync(int grassTrimmerId, GrassTrimmerFormModel formModel)
        {
            Product grassTrimmer = await this.dbContext
                .Products
                .Where(gt => gt.IsAvailable)
                .FirstAsync(gt => gt.Id == grassTrimmerId);

            grassTrimmer.Model = formModel.Model;
            grassTrimmer.Power = formModel.Power;
            grassTrimmer.CuttingWidth = formModel.CuttingWidth;
            grassTrimmer.ImageUrl = formModel.ImageUrl;
            grassTrimmer.Description = formModel.Description;
            grassTrimmer.Price = formModel.Price;
            grassTrimmer.Availability = formModel.Availability;

            await this.dbContext.SaveChangesAsync();
        }


        public async Task<bool> ExistByModelAsync(string automowerModel)
        {
            bool result = await this.dbContext
                .Products
                .Where(gt => gt.IsAvailable)
                .AnyAsync(gt => gt.Model == automowerModel);

            return result;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Products
                .Where(gt => gt.IsAvailable)
                .AnyAsync(gt => gt.Id == id);

            return result;
        }

        public async Task<GrassTrimmerDetailsViewModel> GetDetailsByIdAsync(int grassTrimmerId)
        {
            Product grassTrimmer = await this.dbContext
               .Products
               .Where(gt => gt.IsAvailable)
               .FirstAsync(gt => gt.Id == grassTrimmerId);

            return new GrassTrimmerDetailsViewModel()
            {
                Id = grassTrimmer.Id,
                Model = grassTrimmer.Model,
                Power = (int)grassTrimmer.Power,
                CuttingWidth = (int)grassTrimmer.CuttingWidth,
                ImageUrl = grassTrimmer.ImageUrl,
                Description = grassTrimmer.Description,
                Price = grassTrimmer.Price,
            };
        }

        public async Task<GrassTrimmerDeleteViewModel> GetGrassTrimmerForDeleteByIdAsync(int grassTrimmerId)
        {
            Product grassTrimmer = await this.dbContext
                .Products
                .Where(gt => gt.IsAvailable)
                .FirstAsync(gt => gt.Id == grassTrimmerId);

            return new GrassTrimmerDeleteViewModel()
            {
                Model = grassTrimmer.Model,
                Availability = grassTrimmer.Availability,
                ImageUrl = grassTrimmer.ImageUrl
            };
        }

        public async Task<GrassTrimmerFormModel> GetGrassTrimmerForEditByIdAsync(int grassTrimmerId)
        {
            Product grassTrimmer = await this.dbContext
                .Products
                .Where(gt => gt.IsAvailable)
                .FirstAsync(gt => gt.Id == grassTrimmerId);

            return new GrassTrimmerFormModel()
            {
                Model = grassTrimmer.Model,
                Power = (int)grassTrimmer.Power,
                CuttingWidth = (int)grassTrimmer.CuttingWidth,
                ImageUrl = grassTrimmer.ImageUrl,
                Description = grassTrimmer.Description,
                Price = grassTrimmer.Price,
                Availability = grassTrimmer.Availability
            };
        }
    }
}
