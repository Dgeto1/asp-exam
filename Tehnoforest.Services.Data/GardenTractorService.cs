namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Services.Data.Models.GardenTractor;
    using Tehnoforest.Web.ViewModels.Chainsaw;
    using Tehnoforest.Web.ViewModels.Enums;
    using Tehnoforest.Web.ViewModels.GardenTractor;

    public class GardenTractorService : IGardenTractorService
    {
        private readonly TehnoforestDbContext dbContext;

        public GardenTractorService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllGardenTractorsFilteredAndPagedServiceModel> AllAsync(AllGardenTractorsQueryModel queryModel)
        {
            IQueryable<GardenTractor> gardenTractorsQuery = this.dbContext
                .GardenTractors
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                gardenTractorsQuery = gardenTractorsQuery
                    .Where(h => EF.Functions.Like(h.Model, wildCard) ||
                    EF.Functions.Like(h.Description, wildCard));
            }

            gardenTractorsQuery = queryModel.GardenTractorsSorting switch
            {
                ProductsSorting.NameAZ => gardenTractorsQuery
                .OrderBy(c => c.Model),
                ProductsSorting.NameZA => gardenTractorsQuery
                .OrderByDescending(h => h.Model),
                ProductsSorting.PriceAscending => gardenTractorsQuery
                .OrderBy(c => c.Price),
                ProductsSorting.PriceDescending =>  gardenTractorsQuery
                .OrderByDescending(c => c.Price)
            };

            IEnumerable<GardenTractorAllViewModel> allGardenTractors = await gardenTractorsQuery
                .Where(gt => gt.IsAvailable)
                .Skip((queryModel.CurrentPage - 1) * queryModel.GardenTractorsPerPage)
                .Take(queryModel.GardenTractorsPerPage)
                .Select(gt => new GardenTractorAllViewModel()
                {
                    Id = gt.Id,
                    Model = gt.Model,
                    CylinderDisplacement = gt.CylinderDisplacement,
                    NetPower = gt.NetPower,
                    ImageUrl = gt.ImageUrl,
                    Price = gt.Price
                })
                .ToArrayAsync();

            int totalGardenTractors = gardenTractorsQuery.Count();

            return new AllGardenTractorsFilteredAndPagedServiceModel()
            {
                TotalGardenTractosrsCount = totalGardenTractors,
                GardenTractors = allGardenTractors
            };
        }

        public async Task<string> CreateAndReturnIdAsync(Web.ViewModels.GardenTractor.GardenTractorFormModel formModel)
        {
            GardenTractor newGardenTractor = new GardenTractor()
            {
                Model = formModel.Model,
                CylinderDisplacement = formModel.CylinderDisplacement,
                NetPower = formModel.NetPower,
                CuttingWidth = formModel.CuttingWidth,
                CuttingHeightMax = formModel.CuttingHeightMax,
                CuttingHeightMin = formModel.CuttingHeightMin,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.Price,
                Availability = formModel.Availability
            };

            await this.dbContext.GardenTractors.AddAsync(newGardenTractor);
            await this.dbContext.SaveChangesAsync();

            return newGardenTractor.Id.ToString();
        }

        public async Task<bool> ExistByModelAsync(string gardenTractorModel)
        {
            bool result = await this.dbContext
                .GardenTractors
                .AnyAsync(gt => gt.Model == gardenTractorModel);

            return result;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .GardenTractors
                .Where(gt => gt.IsAvailable)
                .AnyAsync(gt => gt.Id == id);

            return result;
        }

        public async Task<GardenTractorDetailsViewModel> GetDetailsByIdAsync(int gardenTractorId)
        {
            GardenTractor gardenTractor = await this.dbContext
                .GardenTractors
                .Where(gt => gt.IsAvailable)
                .FirstAsync(gt => gt.Id == gardenTractorId);

            return new GardenTractorDetailsViewModel()
            {
                Model = gardenTractor.Model,
                CylinderDisplacement = gardenTractor.CylinderDisplacement,
                NetPower = gardenTractor.NetPower,
                CuttingWidth = gardenTractor.CuttingWidth,
                CuttingHeightMax = gardenTractor.CuttingHeightMax,
                CuttingHeightMin = gardenTractor.CuttingHeightMin,
                Description = gardenTractor.Description,
                ImageUrl = gardenTractor.ImageUrl,
                Price = gardenTractor.Price
            };
        }

        public async Task<GardenTractorFormModel> GetGardenTractorForEditByIdAsync(int gardenTractorId)
        {
            GardenTractor gardenTractor = await this.dbContext
                .GardenTractors
                .Where(gt => gt.IsAvailable)
                .FirstAsync(gt => gt.Id == gardenTractorId);

            return new GardenTractorFormModel()
            {
                Model = gardenTractor.Model,
                CylinderDisplacement = gardenTractor.CylinderDisplacement,
                NetPower = gardenTractor.NetPower,
                CuttingWidth = gardenTractor.CuttingWidth,
                CuttingHeightMax = gardenTractor.CuttingHeightMax,
                CuttingHeightMin = gardenTractor.CuttingHeightMin,
                Description = gardenTractor.Description,
                ImageUrl = gardenTractor.ImageUrl,
                Price = gardenTractor.Price,
                Availability = gardenTractor.Availability
            };
        }

        public async Task EditGardenTractorByIdAndFormModelAsync(int gardenTractorId, GardenTractorFormModel formModel)
        {
            GardenTractor gardenTractor = await this.dbContext
               .GardenTractors
               .Where(gt => gt.IsAvailable)
               .FirstAsync(gt => gt.Id == gardenTractorId);

            gardenTractor.Model = formModel.Model;
            gardenTractor.CylinderDisplacement = formModel.CylinderDisplacement;
            gardenTractor.NetPower = formModel.NetPower;
            gardenTractor.CuttingWidth = formModel.CuttingWidth;
            gardenTractor.CuttingHeightMax = formModel.CuttingHeightMax;
            gardenTractor.CuttingHeightMin = formModel.CuttingHeightMin;
            gardenTractor.Description = formModel.Description;
            gardenTractor.ImageUrl = formModel.ImageUrl;
            gardenTractor.Price = formModel.Price;
            gardenTractor.Availability = formModel.Availability;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<GardenTractorDeleteViewModel> GetGardenTractorForDeleteByIdAsync(int gardenTractorId)
        {
            GardenTractor gardenTractor = await this.dbContext
                .GardenTractors
                .Where(gt => gt.IsAvailable)
                .FirstAsync(gt => gt.Id == gardenTractorId);

            return new GardenTractorDeleteViewModel()
            {
                Model = gardenTractor.Model,
                Availability = gardenTractor.Availability,
                ImageUrl = gardenTractor.ImageUrl
            };
        }

        public async Task DeleteGardenTractorByIdAsync(int gardenTractorId)
        {
            GardenTractor gardenTractor = await this.dbContext
                .GardenTractors
                .Where(gt => gt.IsAvailable)
                .FirstAsync(gt => gt.Id == gardenTractorId);

            gardenTractor.IsAvailable = false;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
