﻿namespace Tehnoforest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Services.Data.Models.Automower;
    using Tehnoforest.Services.Data.Models.Chainsaw;
    using Tehnoforest.Web.ViewModels.Automower;
    using Tehnoforest.Web.ViewModels.Chainsaw;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class AutomowerController : Controller
    {
        IAutomowerService automowerService;

        public AutomowerController(IAutomowerService automowerService)
        {
            this.automowerService = automowerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllAutomowersQueryModel queryModel)
        {
            AllAutomowersFilteredAndPagedServiceModel serviceModel =
                await this.automowerService.AllAsync(queryModel);

            queryModel.Automowers = serviceModel.Automowers;
            queryModel.TotalAutomowers = serviceModel.TotalAutomowersCount;

            return this.View(queryModel);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            AutomowerFormModel formModel = new AutomowerFormModel();

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AutomowerFormModel formModel)
        {
            bool automowerExists =
                await this.automowerService.ExistByModelAsync(formModel.Model);
            if (automowerExists)
            {
                this.ModelState.AddModelError(nameof(formModel.Model), "Избраната косачка вече съществува!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(formModel);
            }
            try
            {
                string automowerId =
                    await this.automowerService.CreateAndReturnIdAsync(formModel);

                await this.automowerService.CreateAndReturnIdAsync(formModel);

                this.TempData[SuccessMessage] = "Косачката е добавена успешно!";
                return this.RedirectToAction("Details", "Automower", new { id = automowerId });
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
            bool automowerExists = await this.automowerService
                .ExistsByIdAsync(id);
            if (!automowerExists)
            {
                this.TempData[ErrorMessage] = "Автоматичната косачка не съществува!";

                return this.RedirectToAction("All", "Automower");
            }

            try
            {
                AutomowerDetailsViewModel viewModel = await this.automowerService
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
