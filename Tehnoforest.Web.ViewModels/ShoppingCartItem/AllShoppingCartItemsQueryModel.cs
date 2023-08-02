using System.ComponentModel.DataAnnotations;
using Tehnoforest.Web.ViewModels.Enums;
using static Tehnoforest.Common.GeneralApplicationConstants;

namespace Tehnoforest.Web.ViewModels.ShoppingCartItem
{
	public class AllShoppingCartItemsQueryModel
	{
		public AllShoppingCartItemsQueryModel()
		{
			this.CurrentPage = DefaultPage;
			this.ProductPerPage = EntitiesPerPage;

			this.Products = new HashSet<ShoppingCartItemViewModel>();
		}

		[Display(Name = "Търси по дума")]
		public string? SearchString { get; set; }

		public int CurrentPage { get; set; }

		[Display(Name = "Покажи продукти на страницата")]
		public int ProductPerPage { get; set; }

		public int TotalProduct { get; set; }

		public IEnumerable<ShoppingCartItemViewModel> Products { get; set; }
	}
}
