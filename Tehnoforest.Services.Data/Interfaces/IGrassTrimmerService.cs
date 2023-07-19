namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Web.ViewModels.GrassTrimer;

    public interface IGrassTrimmerService
    {
        Task<bool> ExistByModelAsync(string automowerModel);

        Task<string> CreateAndReturnIdAsync(GrassTrimmerFormModel formModel);
    }
}
