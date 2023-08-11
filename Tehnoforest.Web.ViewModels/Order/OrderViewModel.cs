using Tehnoforest.Data.Models;

namespace Tehnoforest.Web.ViewModels.Order
{
    public class OrderViewModel
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public List<OrderItem> OrderItems { get; set; } = null!;
    }
}
