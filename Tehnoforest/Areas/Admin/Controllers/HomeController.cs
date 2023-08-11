using Microsoft.AspNetCore.Mvc;

namespace Tehnoforest.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
