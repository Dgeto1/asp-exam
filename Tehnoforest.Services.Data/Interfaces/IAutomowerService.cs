namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Services.Data.Models.Automower;
    using Tehnoforest.Web.ViewModels.Automower;
    using Tehnoforest.Web.ViewModels.GardenTractor;

    public interface IAutomowerService
    {
        Task<bool> ExistByModelAsync(string automowerModel);

        Task<string> CreateAndReturnIdAsync(AutomowerFormModel formModel);

        Task<AllAutomowersFilteredAndPagedServiceModel> AllAsync(AllAutomowersQueryModel queryModel);

        Task<bool> ExistsByIdAsync(int id);
    }
}
