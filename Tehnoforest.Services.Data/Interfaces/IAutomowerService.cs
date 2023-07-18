namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Services.Data.Models.Automower;
    using Tehnoforest.Web.ViewModels.Automower;
    using Tehnoforest.Web.ViewModels.Chainsaw;

    public interface IAutomowerService
    {
        Task<bool> ExistByModelAsync(string automowerModel);

        Task<string> CreateAndReturnIdAsync(AutomowerFormModel formModel);

        Task<AllAutomowersFilteredAndPagedServiceModel> AllAsync(AllAutomowersQueryModel queryModel);

        Task<AutomowerDetailsViewModel> GetDetailsByIdAsync(int automowerId);

        Task<AutomowerFormModel> GetAutomowerForEditByIdAsync(int automowerId);

        Task EditAutomowerByIdAndFormModelAsync(int automowerId, AutomowerFormModel formModel);

        Task<bool> ExistsByIdAsync(int id);

        Task<AutomowerDeleteViewModel> GetAutomowerForDeleteByIdAsync(int automowerId);

        Task DeleteAutomowerByIdAsync(int automowerId);
    }
}
