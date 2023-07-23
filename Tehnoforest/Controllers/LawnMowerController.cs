namespace Tehnoforest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Services.Data.Models.LawnMower;
    using Tehnoforest.Web.ViewModels.LawnMower;

    using static Tehnoforest.Common.NotificationMessagesConstants;

    [Authorize]
    public class LawnMowerController : Controller
    {
        ILawnMowerService lawnMowerService;

        public LawnMowerController(ILawnMowerService lawnMowerService)
        {
            this.lawnMowerService = lawnMowerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllLawnMowersQueryModel queryModel)
        {
            AllLawnMowersFilteredAndPagedServiceModel serviceModel =
                await this.lawnMowerService.AllAsync(queryModel);

            queryModel.LawnMowers = serviceModel.LawnMowers;
            queryModel.TotalLawnMowers = serviceModel.TotalLawnMowersCount;

            return this.View(queryModel);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            LawnMowerFormModel formModel = new LawnMowerFormModel();

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LawnMowerFormModel formModel)
        {
            bool lawnMowerExists =
                await this.lawnMowerService.ExistByModelAsync(formModel.Model);
            if (lawnMowerExists)
            {
                this.ModelState.AddModelError(nameof(formModel.Model), "Избраната косачка вече съществува!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(formModel);
            }
            try
            {
                string lawnMowerId =
                    await this.lawnMowerService.CreateAndReturnIdAsync(formModel);


                this.TempData[SuccessMessage] = "Косачката е добавена успешно!";
                return this.RedirectToAction("Details", "LawnMower", new { id = lawnMowerId });
            }
            catch (Exception)
            {

                this.ModelState.AddModelError(string.Empty, "Нещо се обърка, докато се добавяше косачката! Моля опитайте отново или се свържете с администраторите!");

                return this.View(formModel);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool lawnMowerExists = await this.lawnMowerService
                .ExistsByIdAsync(id);
            if (!lawnMowerExists)
            {
                this.TempData[ErrorMessage] = "Косачката не съществува!";

                return this.RedirectToAction("All", "LawnMower");
            }

            try
            {
                LawnMowerDetailsViewModel viewModel = await this.lawnMowerService
                .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool lawnMowerExists = await this.lawnMowerService
               .ExistsByIdAsync(id);
            if (!lawnMowerExists)
            {
                this.TempData[ErrorMessage] = "Косачката не съществува!";

                return this.RedirectToAction("All", "LawnMower");
            }

            LawnMowerFormModel formModel = await this.lawnMowerService
                .GetLawnMowerForEditByIdAsync(id);

            return this.View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, LawnMowerFormModel formModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool lawnMowerExists = await this.lawnMowerService
             .ExistsByIdAsync(id);
            if (!lawnMowerExists)
            {
                this.TempData[ErrorMessage] = "Kосачката не съществува!";

                return this.RedirectToAction("All", "LawnMower");
            }

            try
            {
                await this.lawnMowerService.EditLawnMowerByIdAndFormModelAsync(id, formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Нещо се обърка! Опитайте отново или се свържете с администратор!");

                return this.View(formModel);
            }

            this.TempData[SuccessMessage] = "Косачката беше редактиран успешно!";
            return this.RedirectToAction("Details", "LawnMower", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool lawnMowerExists = await this.lawnMowerService
            .ExistsByIdAsync(id);
            if (!lawnMowerExists)
            {
                this.TempData[ErrorMessage] = "Косачката не съществува!";

                return this.RedirectToAction("All", "LawnMower");
            }

            try
            {
                LawnMowerDeleteViewModel viewModel =
                    await this.lawnMowerService.GetLawnMowerForDeleteByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, LawnMowerDeleteViewModel formModel)
        {
            bool lawnMowerExists = await this.lawnMowerService
           .ExistsByIdAsync(id);
            if (!lawnMowerExists)
            {
                this.TempData[ErrorMessage] = "Косачката не съществува!";

                return this.RedirectToAction("All", "LawnMower");
            }

            try
            {
                await this.lawnMowerService.DeleteLawnMowerByIdAsync(id);
                this.TempData[WarningMessage] = "Успешно премахнахте косачката!";

                return this.RedirectToAction("All", "LawnMower");
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
