namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.Automower;

    public class AutomowerService : IAutomowerService
    {
        private readonly TehnoforestDbContext dbContext;

        public AutomowerService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
