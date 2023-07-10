namespace Tehnoforest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Tehnoforest.Web.ViewModels.Chainsaw;

    [Authorize]
    public class ChainsawController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            ChainsawFormModel formModel = new ChainsawFormModel();

            return View(formModel);
        }
    }
}
