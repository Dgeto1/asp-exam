namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Services.Data.Models.Automower;
    using Tehnoforest.Web.ViewModels.Automower;

    public interface IAutomowerService
    {
        Task<bool> ExistByModelAsync(string automowerModel);

        Task<string> CreateAndReturnIdAsync(AutomowerFormModel formModel);

        Task<AllAutomowersFilteredAndPagedServiceModel> AllAsync(AllAutomowersQueryModel queryModel);

        Task<AutomowerDetailsViewModel> GetDetailsByIdAsync(int automowerId);

        Task<bool> ExistsByIdAsync(int id);
    }
}
