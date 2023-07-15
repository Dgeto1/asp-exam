namespace Tehnoforest.Controllers
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
                return this.GeneralError();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool chainsawExists = await this.chainsawService
                .ExistsByIdAsync(id);
            if (!chainsawExists)
            {
                this.TempData[ErrorMessage] = "Верижният трион не съществува!";

                return this.RedirectToAction("All", "Chainsaw");
            }

            try
            {
                ChainsawDetailsViewModel viewModel = await this.chainsawService
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
            bool chainsawExists = await this.chainsawService
               .ExistsByIdAsync(id);
            if (!chainsawExists)
            {
                this.TempData[ErrorMessage] = "Верижният трион не съществува!";

                return this.RedirectToAction("All", "Chainsaw");
            }

            ChainsawFormModel formModel = await this.chainsawService
                .GetChainsawForEditByIdAsync(id);

            return this.View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ChainsawFormModel formModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(formModel);      
            }

            bool chainsawExists = await this.chainsawService
             .ExistsByIdAsync(id);
            if (!chainsawExists)
            {
                this.TempData[ErrorMessage] = "Верижният трион не съществува!";

                return this.RedirectToAction("All", "Chainsaw");
            }

            try
            {
                await this.chainsawService.EditChainsawByIdAndFormModel(id, formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Нещо се обърка! Опитайте отново или се свържете с администратор!");

                return this.View(formModel);
            }

            return this.RedirectToAction("Details", "Chainsaw", new {id});
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Нещо се обърка! Опитайте отново или се свържете с администратор!";

            return this.RedirectToAction("Index", "Home");
        }
    }
}
