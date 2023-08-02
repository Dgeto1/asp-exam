using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tehnoforest.Services.Data;
using Tehnoforest.Services.Data.Interfaces;
using Tehnoforest.Services.Data.Models.LawnMower;
using Tehnoforest.Services.Data.Models.ShoppingCart;
using Tehnoforest.Web.ViewModels.ShoppingCartItem;

namespace Tehnoforest.Controllers
{
    public class ShoppingCartItemController : Controller
    {
        private readonly IUserService userService;
        public ShoppingCartItemController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddProductToShoppingCart(int productId)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            if (!await userService.AddShoppingCartItem(productId, userEmail))
            {
                return RedirectToAction("Error", "Home");
            }

            return Ok(); 
        }

        /*[HttpGet]
        [Authorize]
        public async Task<IActionResult> All()
        {
            List<ShoppingCartItemViewModel> products =
                new List<ShoppingCartItemViewModel>();

            string userId = User.GetId();

            var items = userService.GetUserShoppingCartItems(userEmail);

			AllShoppingCartItemsFilteredAndPagedServiceModel serviceModel =
			   await userService.GetUserShoppingCartItems(userEmail);


		}*/

        /*[HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateUserShoppingCartItem([DataSourceRequest] DataSourceRequest request, ShoppingCartItemViewModel item)
        {
            if (item != null && ModelState.IsValid)
            {
                await userService.ChangeShoppingCartItemQuantity(item.ProductId, item.ShoppingCartId, item.Quantity);
            }

            return Json(new[] { item }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoverUserShoppingCartItem([DataSourceRequest] DataSourceRequest request, ShoppingCartItemViewModel item)
        {
            if (item != null && ModelState.IsValid)
            {
                await userService.RemoveShoppingCartItem(item.ProductId, item.ShoppingCartId);
            }

            return Json(new[] { item }.ToDataSourceResult(request, ModelState));
        }*/

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetShoppingCartItemsCount()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var itemsCount = await userService.GetUserShoppingCartItemsCount(userEmail);

            return Json(itemsCount);
        }

        /*[HttpGet]
        [Authorize]
        public async Task<IActionResult> CheckoutShoppingCart()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var shoppingCartItems = userService.GetUserShoppingCartItems(userEmail).ToList();

            if (!await orderService.AddSalesOrder(shoppingCartItems, userEmail))
            {
                return RedirectToAction("Error", "Home");
            }

            if (!await userService.ClearUserShoppingCart(userEmail))
            {
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Index", "Orders");
        }*/
    }
}
