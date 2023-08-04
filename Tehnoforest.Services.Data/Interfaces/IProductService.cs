using Tehnoforest.Data.Models;

namespace Tehnoforest.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(int id);
    }
}
