namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Web.ViewModels.ShoppingCart;

    public interface IUserService
    {
        IQueryable<ShoppingCartItemFormModel> GetUserShoppingCartItems(string userEmail);

        Task<int> GetUserShoppingCartItemsCount(string userEmail);

        Task<bool> AddShoppingCartItem(int productId, string userEmail);

        Task<bool> ChangeShoppingCartItemQuantity(int productId, string userEmail, int quantity);

        Task<bool> RemoveShoppingCartItem(int productId, string userEmail);

        Task<bool> ClearUserShoppingCart(string userEmail);
    }
}
