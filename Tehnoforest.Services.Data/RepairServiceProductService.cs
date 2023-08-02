using Tehnoforest.Data;
using Tehnoforest.Data.Models;
using Tehnoforest.Services.Data.Interfaces;
using Tehnoforest.Web.ViewModels.RepairServiceProduct;

namespace Tehnoforest.Services.Data
{
    public class RepairServiceProductService : IRepairServiceProductService
    {
        private readonly TehnoforestDbContext dbContext;

        public RepairServiceProductService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<string> CreateAndReturnIdAsync(RepairServiceProductFormModel formModel)
        {
            RepairServiceProduct repairServiceProduct = new RepairServiceProduct()
            {
                ClientName = formModel.ClientName,
                BrandMachine = formModel.BrandMachine,
                ModelMachine = formModel.ModelMachine,
                ProblemDescription = formModel.ProblemDescription,
                DateOfAcceptance = formModel.DateOfAcceptance,
                DateOfReturning = formModel.DateOfReturning
            };

            await this.dbContext.AddAsync(repairServiceProduct);
            await this.dbContext.SaveChangesAsync();

            return repairServiceProduct.Id.ToString();
        }
    }
}
