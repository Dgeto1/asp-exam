namespace Tehnoforest.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.GrassTrimer;

    using static Common.NotificationMessagesConstants;
    public class GrassTrimmerController : Controller
    {
        private readonly IGrassTrimmerService grassTrimmerService;

        public GrassTrimmerController(IGrassTrimmerService grassTrimmerService)
        {
            this.grassTrimmerService = grassTrimmerService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            GrassTrimmerFormModel formModel = new GrassTrimmerFormModel();

            return View(formModel);
        }

        [HttpPost]
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
    }
}
