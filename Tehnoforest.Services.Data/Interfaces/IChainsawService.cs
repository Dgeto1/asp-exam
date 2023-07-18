namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Services.Data.Models.Chainsaw;
    using Tehnoforest.Web.ViewModels.Chainsaw;

    public interface IChainsawService
    {
        Task<bool> ExistByModelAsync(string chainsawModel);

        Task<string> CreateAndReturnIdAsync(ChainsawFormModel formModel);

        Task<AllChainsawsFilteredAndPagedServiceModel> AllAsync(AllChainsawsQueryModel queryModel);

        Task<bool> ExistsByIdAsync(int id);

        Task<ChainsawFormModel> GetChainsawForEditByIdAsync(int chainsawId);

        Task<ChainsawDetailsViewModel> GetDetailsByIdAsync(int chainsawId);

        Task EditChainsawByIdAndFormModelAsync(int chainsawId, ChainsawFormModel formModel);

        Task<ChainsawDeleteViewModel> GetChainsawForDeleteByIdAsync(int chainsawId);

        Task DeleteChainsawByIdAsync(int chainsawId);
    }
}
