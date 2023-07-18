namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.Automower;
    using Tehnoforest.Web.ViewModels.Chainsaw;
    using Tehnoforest.Web.ViewModels.GardenTractor;

    public class GardenTractorService : IGardenTractorService
    {
        private readonly TehnoforestDbContext dbContext;

        public GardenTractorService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
