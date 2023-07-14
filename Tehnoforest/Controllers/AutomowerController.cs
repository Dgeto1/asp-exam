namespace Tehnoforest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.Automower;
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
        public async Task<IActionResult> All()
        {
            // TODO:  
            return this.Ok();
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
                await this.automowerService.CreateAsync(formModel);

                this.TempData[SuccessMessage] = "Косачката е добавена успешно!";
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
