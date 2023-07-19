namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.GrassTrimer;


    public class GrassTrimmerService : IGrassTrimmerService
    {
        private readonly TehnoforestDbContext dbContext;

        public GrassTrimmerService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
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
