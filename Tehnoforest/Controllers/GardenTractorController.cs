namespace Tehnoforest.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.GardenTractor;
    using static Common.NotificationMessagesConstants;

    public class GardenTractorController : Controller
    {
        private readonly IGardenTractorService gardenTractorService;

        public GardenTractorController(IGardenTractorService gardenTractorService)
        {
            this.gardenTractorService = gardenTractorService;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            GardenTractorFormModel formModel = new GardenTractorFormModel();

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GardenTractorFormModel formModel)
        {
            bool gardenTractorExists =
                await this.gardenTractorService.ExistByModelAsync(formModel.Model);
            if (gardenTractorExists)
            {
                this.ModelState.AddModelError(nameof(formModel.Model), "Избраният градински трактор вече съществува!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(formModel);
            }

            try
            {
                string gardenTractorId =
                    await this.gardenTractorService.CreateAndReturnIdAsync(formModel);

                this.TempData[SuccessMessage] = "Моторният трион е добавен успешно!";
                return this.RedirectToAction("Details", "GardenTractor", new { id = gardenTractorId });
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
