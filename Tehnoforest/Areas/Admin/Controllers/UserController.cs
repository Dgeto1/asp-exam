namespace Tehnoforest.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.User;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> viewModel = await this.userService.AllAsync();
            return View(viewModel);
        }
    }
}
