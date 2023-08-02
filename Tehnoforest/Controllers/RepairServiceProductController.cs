using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tehnoforest.Services.Data;
using Tehnoforest.Services.Data.Interfaces;
using Tehnoforest.Web.ViewModels.Automower;
using Tehnoforest.Web.ViewModels.RepairServiceProduct;

using static Tehnoforest.Common.NotificationMessagesConstants;

namespace Tehnoforest.Controllers
{
    public class RepairServiceProductController : Controller
    {
        private readonly IRepairServiceProductService repairService;

        public RepairServiceProductController(IRepairServiceProductService repairService)
        {
            this.repairService = repairService;

        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Add()
        {
            RepairServiceProductFormModel formModel = new RepairServiceProductFormModel();

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RepairServiceProductFormModel formModel)
        {
            try
            {
                string productId =
                    await this.repairService.CreateAndReturnIdAsync(formModel);

                this.TempData[SuccessMessage] = "Машината е добавена успешно!";
                return this.RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                this.ModelState.AddModelError(string.Empty, "Нещо се обърка, докато се добавяше косачката! Моля опитайте отново или се свържете с администраторите!");

                return this.View(formModel);
            }
        }
    }
}
