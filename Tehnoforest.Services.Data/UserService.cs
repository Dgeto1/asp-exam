using Tehnoforest.Data;
using Tehnoforest.Services.Data.Interfaces;
using Tehnoforest.Web.ViewModels.ShoppingCart;

namespace Tehnoforest.Services.Data
{
    public class UserService : IUserService
    {
        private readonly TehnoforestDbContext dbContext;

        public UserService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<bool> AddShoppingCartItem(int productId, string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeShoppingCartItemQuantity(int productId, string userEmail, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ClearUserShoppingCart(string userEmail)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ShoppingCartItemFormModel> GetUserShoppingCartItems(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUserShoppingCartItemsCount(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveShoppingCartItem(int productId, string userEmail)
        {
            throw new NotImplementedException();
        }
    }
}
