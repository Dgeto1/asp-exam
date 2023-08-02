using Tehnoforest.Web.ViewModels.ShoppingCartItem;

namespace Tehnoforest.Services.Data.Models.ShoppingCart
{
	public class AllShoppingCartItemsFilteredAndPagedServiceModel
	{
        public AllShoppingCartItemsFilteredAndPagedServiceModel()
        {
            ShoppingCartItems = new HashSet<ShoppingCartItemViewModel>();
        }

        public int TotalShoppingCartItems { get; set; }
        public IEnumerable<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }
	}
}
