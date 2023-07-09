namespace Tehnoforest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ChainsawController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
