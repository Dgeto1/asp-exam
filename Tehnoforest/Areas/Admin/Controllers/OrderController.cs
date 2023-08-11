namespace Tehnoforest.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.Order;
    public class OrderController : BaseAdminController
    {
        private readonly IOrdersService ordersService;
        public OrderController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<OrderViewModel> viewModel = await this.ordersService.AllAsync();
            return View(viewModel);
        }
    }
}
