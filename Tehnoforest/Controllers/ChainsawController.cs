﻿namespace Tehnoforest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Services.Data.Models.Chainsaw;
    using Tehnoforest.Web.ViewModels.Chainsaw;
    using static Common.NotificationMessagesConstants;


    [Authorize]
    public class ChainsawController : Controller
    {
        private readonly IChainsawService chainsawService;

        public ChainsawController(IChainsawService chainsawService)
        {
            this.chainsawService = chainsawService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllChainsawsQueryModel queryModel)
        {
            AllChainsawsFilteredAndPagedServiceModel serviceModel =
                await this.chainsawService.AllAsync(queryModel);

            queryModel.Chainsaws = serviceModel.Chainsaws;
            queryModel.TotalChainsaws = serviceModel.TotalChainsawsCount;

            return this.View(queryModel);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
                ChainsawFormModel formModel = new ChainsawFormModel();

                return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ChainsawFormModel formModel)
        {
            bool chainsawExists =
                await this.chainsawService.ExistByModelAsync(formModel.Model);
            if(chainsawExists)
            {
                this.ModelState.AddModelError(nameof(formModel.Model), "Избраният моторен трион вече съществува!");
            }
            
            if(!this.ModelState.IsValid)
            {
                return this.View(formModel);
            }
            try
            {
                await this.chainsawService.CreateAsync(formModel);

                this.TempData[SuccessMessage] = "Моторният трион е добавен успешно!";
                return this.RedirectToAction("All", "Chainsaw");
            }
            catch (Exception)
            {

                this.ModelState.AddModelError(string.Empty, "Нещо се обърка, докато се добавяше моторен трион! Моля опитайте отново или се свържете с администраторите!");

                return this.View(formModel);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            ChainsawDetailsViewModel? viewModel = await this.chainsawService
                .GetDetailsByIdAsync(id);

            if (viewModel == null)
            {
                this.TempData[ErrorMessage] = "Верижният трион не съществува!";

                return this.RedirectToAction("All", "Chainsaw");
            }

            return View(viewModel);
        }
    }
}
