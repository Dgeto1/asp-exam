namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Services.Data.Models.Automower;
    using Tehnoforest.Services.Data.Models.LawnMower;
    using Tehnoforest.Web.ViewModels.Automower;
    using Tehnoforest.Web.ViewModels.LawnMower;

    public interface ILawnMowerService
    {
        Task<bool> ExistByModelAsync(string lawnMowerModel);

        Task<string> CreateAndReturnIdAsync(LawnMowerFormModel formModel);

        Task<AllLawnMowersFilteredAndPagedServiceModel> AllAsync(AllLawnMowersQueryModel queryModel);

        Task<LawnMowerDetailsViewModel> GetDetailsByIdAsync(int lawnMowerId);

        Task<LawnMowerFormModel> GetLawnMowerForEditByIdAsync(int lawnMowerId);

        Task EditLawnMowerByIdAndFormModelAsync(int lawnMowerId, LawnMowerFormModel formModel);

        Task<bool> ExistsByIdAsync(int id);

        Task<LawnMowerDeleteViewModel> GetLawnMowerForDeleteByIdAsync(int lawnMowerId);

        Task DeleteLawnMowerByIdAsync(int lawnMowerId);
    }
}
