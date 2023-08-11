namespace Tehnoforest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Services.Data.Models.GardenTractor;
    using Tehnoforest.Web.ViewModels.GardenTractor;

    using static Tehnoforest.Common.GeneralApplicationConstants;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class GardenTractorController : Controller
    {
        private readonly IGardenTractorService gardenTractorService;

        public GardenTractorController(IGardenTractorService gardenTractorService)
        {
            this.gardenTractorService = gardenTractorService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllGardenTractorsQueryModel queryModel)
        {
            AllGardenTractorsFilteredAndPagedServiceModel serviceModel =
                await this.gardenTractorService.AllAsync(queryModel);

            queryModel.GardenTractors = serviceModel.GardenTractors;
            queryModel.TotalGardenTractor = serviceModel.TotalGardenTractosrsCount;

            return this.View(queryModel);
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add()
        {
            GardenTractorFormModel formModel = new GardenTractorFormModel();

            return View(formModel);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
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

                this.TempData[SuccessMessage] = "Градинският трактор е добавен успешно!";
                return this.RedirectToAction("Details", "GardenTractor", new { id = gardenTractorId });
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool gardenTractorExists = await this.gardenTractorService
                .ExistsByIdAsync(id);
            if (!gardenTractorExists)
            {
                this.TempData[ErrorMessage] = "Градинският трактор не съществува!";

                return this.RedirectToAction("All", "GardenTractor");
            }

            try
            {
                GardenTractorDetailsViewModel viewModel = await this.gardenTractorService
                .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id)
        {
            bool gardenTractorExists = await this.gardenTractorService
                .ExistsByIdAsync(id);
            if (!gardenTractorExists)
            {
                this.TempData[ErrorMessage] = "Градинският трактор не съществува!";

                return this.RedirectToAction("All", "GardenTractor");
            }

            GardenTractorFormModel formModel = await this.gardenTractorService
                .GetGardenTractorForEditByIdAsync(id);

            return this.View(formModel);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id, GardenTractorFormModel formModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool gardenTractorExists = await this.gardenTractorService
             .ExistsByIdAsync(id);
            if (!gardenTractorExists)
            {
                this.TempData[ErrorMessage] = "Градинският трактор не съществува!";

                return this.RedirectToAction("All", "GardenTractor");
            }

            try
            {
                await this.gardenTractorService.EditGardenTractorByIdAndFormModelAsync(id, formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Нещо се обърка! Опитайте отново или се свържете с администратор!");

                return this.View(formModel);
            }

            this.TempData[SuccessMessage] = "Градинският трактор беше редактиран успешно!";
            return this.RedirectToAction("Details", "GardenTractor", new { id });
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            bool gardenTractorExists = await this.gardenTractorService
            .ExistsByIdAsync(id);
            if (!gardenTractorExists)
            {
                this.TempData[ErrorMessage] = "Градинският трактор не съществува!";

                return this.RedirectToAction("All", "GardenTractor");
            }

            try
            {
                GardenTractorDeleteViewModel viewModel =
                    await this.gardenTractorService.GetGardenTractorForDeleteByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Delete(int id, GardenTractorDeleteViewModel formModel)
        {
            bool gardenTractorExists = await this.gardenTractorService
           .ExistsByIdAsync(id);
            if (!gardenTractorExists)
            {
                this.TempData[ErrorMessage] = "Верижният трион не съществува!";

                return this.RedirectToAction("All", "GardenTractor");
            }

            try
            {
                await this.gardenTractorService.DeleteGardenTractorByIdAsync(id);
                this.TempData[WarningMessage] = "Успешно премахнахте градинския трактор!";

                return this.RedirectToAction("All", "GardenTractor");
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
