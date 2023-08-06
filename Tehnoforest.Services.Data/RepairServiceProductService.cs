using Microsoft.EntityFrameworkCore;
using Tehnoforest.Data;
using Tehnoforest.Data.Models;
using Tehnoforest.Services.Data.Interfaces;
using Tehnoforest.Services.Data.Models.RepairServiceProduct;
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

        public async Task<AllRepairServiceProductsModel> AllAsync(AllRepairServiceProductsQueryModel queryModel)
        {
            IQueryable<RepairServiceProduct> repairServiceProductsQuery = this.dbContext
                .RepairServiceProducts
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                repairServiceProductsQuery = repairServiceProductsQuery
                    .Where(h => EF.Functions.Like(h.Id.ToString(), wildCard));
            }

            IEnumerable<RepairServiceProductAllViewModel> repairServiceProducts = await repairServiceProductsQuery
                    .Select(p => new RepairServiceProductAllViewModel()
                    {
                        Id = p.Id,
                        ClientName = p.ClientName,
                        BrandMachine = p.BrandMachine,
                        ModelMachine = p.ModelMachine,
                        DateReturned = p.DateOfReturning
                    })
                    .ToArrayAsync();

            return new AllRepairServiceProductsModel()
            {
                Products = repairServiceProducts
            };

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

        public async Task<bool> ExistsByIdAsync(string id)
        {
            bool result = await this.dbContext
                .RepairServiceProducts
                .AnyAsync(p => p.Id.ToString() == id);

            return result;
        }

        public async Task<RepairServiceProductDetailsViewModel> GetDetailsByIdAsync(string productID)
        {
            RepairServiceProduct product = await this.dbContext
                .RepairServiceProducts
                .FirstAsync(a => a.Id.ToString() == productID);

            return new RepairServiceProductDetailsViewModel()
            {
                ClientName = product.ClientName,
                BrandMachine = product.BrandMachine,
                ModelMachine = product.ModelMachine,
                ProblemDescription = product.ProblemDescription,
                DateOfAcceptance = product.DateOfAcceptance,
                DateReturned = product.DateOfReturning
            };
        }
    }
}
