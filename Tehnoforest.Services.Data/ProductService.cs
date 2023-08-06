using Microsoft.EntityFrameworkCore;
using Tehnoforest.Data;
using Tehnoforest.Data.Models;
using Tehnoforest.Services.Data.Interfaces;

namespace Tehnoforest.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly TehnoforestDbContext dbContext;
        public ProductService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product product = await this.dbContext
                .Products
                .Where(p => p.IsAvailable)
                .FirstAsync(p => p.Id == id);

            return product;
        }
    }
}
