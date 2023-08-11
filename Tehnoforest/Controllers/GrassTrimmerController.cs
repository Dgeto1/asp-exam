namespace Tehnoforest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Services.Data.Models.GrassTrimmer;
    using Tehnoforest.Web.ViewModels.GrassTrimer;
    using Tehnoforest.Web.ViewModels.GrassTrimmer;

    using static Tehnoforest.Common.GeneralApplicationConstants;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class GrassTrimmerController : Controller
    {
        private readonly IGrassTrimmerService grassTrimmerService;

        public GrassTrimmerController(IGrassTrimmerService grassTrimmerService)
        {
            this.grassTrimmerService = grassTrimmerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllGrassTrimmersQueryModel queryModel)
        {
            AllGrassTrimmersFilteredAndPagedServiceModel serviceModel =
                await this.grassTrimmerService.AllAsync(queryModel);

            queryModel.GrassTrimmers = serviceModel.GrassTrimmers;
            queryModel.TotalGrassTrimmers = serviceModel.TotalGrassTrimmersCount;

            return this.View(queryModel);
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add()
        {
            GrassTrimmerFormModel formModel = new GrassTrimmerFormModel();

            return View(formModel);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add(GrassTrimmerFormModel formModel)
        {
            bool grassTrimmerExists =
                await this.grassTrimmerService.ExistByModelAsync(formModel.Model);
            if (grassTrimmerExists)
            {
                this.ModelState.AddModelError(nameof(formModel.Model), "Избраната моторна коса вече съществува!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(formModel);
            }
            try
            {
                string grassTrimmerId =
                    await this.grassTrimmerService.CreateAndReturnIdAsync(formModel);

                this.TempData[SuccessMessage] = "Моторната коса е добавена успешно!";
                return this.RedirectToAction("Details", "GrassTrimmer", new { id = grassTrimmerId });
            }
            catch (Exception)
            {

                this.ModelState.AddModelError(string.Empty, "Нещо се обърка, докато се добавяше косачката! Моля опитайте отново или се свържете с администраторите!");

                return this.View(formModel);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            bool grassTrimmerExists = await this.grassTrimmerService
               .ExistsByIdAsync(id);
            if (!grassTrimmerExists)
            {
                this.TempData[ErrorMessage] = "Моторната коса не съществува!";

                return this.RedirectToAction("All", "GrassTrimmer");
            }

            try
            {
                GrassTrimmerDetailsViewModel viewModel = await this.grassTrimmerService
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
            bool grassTrimmerExists = await this.grassTrimmerService
               .ExistsByIdAsync(id);
            if (!grassTrimmerExists)
            {
                this.TempData[ErrorMessage] = "Моторната коса не съществува!";

                return this.RedirectToAction("All", "GrassTrimmer");
            }

            GrassTrimmerFormModel formModel = await this.grassTrimmerService
                .GetGrassTrimmerForEditByIdAsync(id);

            return this.View(formModel);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id, GrassTrimmerFormModel formModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool grassTrimmerExists = await this.grassTrimmerService
             .ExistsByIdAsync(id);
            if (!grassTrimmerExists)
            {
                this.TempData[ErrorMessage] = "Моторната коса не съществува!";

                return this.RedirectToAction("All", "GrassTrimmer");
            }

            try
            {
                await this.grassTrimmerService.EditGrassTrimmerByIdAndFormModelAsync(id, formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Нещо се обърка! Опитайте отново или се свържете с администратор!");

                return this.View(formModel);
            }

            this.TempData[SuccessMessage] = "Моторната коса беше редактиран успешно!";
            return this.RedirectToAction("Details", "GrassTrimmer", new { id });
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            bool grassTrimmerEsists = await this.grassTrimmerService
            .ExistsByIdAsync(id);
            if (!grassTrimmerEsists)
            {
                this.TempData[ErrorMessage] = "Моторната коса не съществува!";

                return this.RedirectToAction("All", "GrassTrimmer");
            }

            try
            {
                GrassTrimmerDeleteViewModel viewModel =
                    await this.grassTrimmerService.GetGrassTrimmerForDeleteByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Delete(int id, GrassTrimmerDeleteViewModel formModel)
        {
            bool grassTrimmerEsists = await this.grassTrimmerService
           .ExistsByIdAsync(id);
            if (!grassTrimmerEsists)
            {
                this.TempData[ErrorMessage] = "Моторната коса не съществува!";

                return this.RedirectToAction("All", "GrassTrimmer");
            }

            try
            {
                await this.grassTrimmerService.DeleteGrassTrimmerByIdAsync(id);
                this.TempData[WarningMessage] = "Успешно премахнахте моторната коса!";

                return this.RedirectToAction("All", "GrassTrimmer");
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
