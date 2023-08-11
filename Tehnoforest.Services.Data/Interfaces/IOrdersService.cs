namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Data.Models;
    using Tehnoforest.Web.ViewModels.Order;

    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);

        Task<IEnumerable<OrderViewModel>> AllAsync();
    }
}
