namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.Chainsaw;

    public class ChainsawService : IChainsawService
    {
        private readonly TehnoforestDbContext dbContext;

        public ChainsawService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddExistingAsync(ChainsawFormModel formModel)
        {
            Chainsaw chainsaw = dbContext.Chainsaws.AnyAsync(c = chainsaw>);
        }

        public async Task CreateAsync(ChainsawFormModel formModel)
        {
            Chainsaw newChainsaw = new Chainsaw()
            {
                Model = formModel.Model,
                Power = formModel.Power,
                CylinderDisplacement = formModel.CylinderDisplacement,
                BarLength = formModel.BarLength,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.Price,
                Availability = 1
            };
            await this.dbContext.Chainsaws.AddAsync(newChainsaw);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistByModelAsync(string chainsawModel)
        {
            bool result = await this.dbContext
                .Chainsaws
                .AnyAsync(c => c.Model == chainsawModel);

            return result;
        }
    }
}
