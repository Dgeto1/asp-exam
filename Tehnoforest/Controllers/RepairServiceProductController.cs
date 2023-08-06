using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tehnoforest.Services.Data.Interfaces;
using Tehnoforest.Services.Data.Models.RepairServiceProduct;
using Tehnoforest.Web.ViewModels.RepairServiceProduct;
using Microsoft.EntityFrameworkCore;

using static Tehnoforest.Common.NotificationMessagesConstants;
using Tehnoforest.Web.ViewModels.Automower;

namespace Tehnoforest.Controllers
{
    public class RepairServiceProductController : Controller
    {
        private readonly IRepairServiceProductService repairService;

        public RepairServiceProductController(IRepairServiceProductService repairService)
        {
            this.repairService = repairService;

        }

        public IActionResult Info()
        {
            return this.View();
        }

        public async Task<IActionResult> All([FromQuery] AllRepairServiceProductsQueryModel queryModel)
        {
            AllRepairServiceProductsModel serviceModel =
                await repairService.AllAsync(queryModel);

            queryModel.RepairServiceProducts = serviceModel.Products;

            return View(queryModel);
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool productExists = await this.repairService
                .ExistsByIdAsync(id);
            if (!productExists)
            {
                this.TempData[ErrorMessage] = "Машината не съществува!";

                return this.RedirectToAction("All", "RepairServiceProduct");
            }

            try
            {
                RepairServiceProductDetailsViewModel viewModel = await this.repairService
                .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }


        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Нещо се обърка! Опитайте отново или се свържете с администратор!";

            return this.RedirectToAction("Index", "Home");
        }
    }
}
