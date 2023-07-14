namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Web.ViewModels.Automower;

    public interface IAutomowerService
    {
        Task<bool> ExistByModelAsync(string automowerModel);

        Task CreateAsync(AutomowerFormModel formModel);
    }
}
