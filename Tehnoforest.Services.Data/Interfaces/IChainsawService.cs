namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Services.Data.Models.Chainsaw;
    using Tehnoforest.Web.ViewModels.Chainsaw;

    public interface IChainsawService
    {
        Task<bool> ExistByModelAsync(string chainsawModel);

        Task CreateAsync(ChainsawFormModel formModel);

        Task<AllChainsawsFilteredAndPagedServiceModel> AllAsync(AllChainsawsQueryModel queryModel);

        Task<ChainsawDetailsViewModel?> GetDetailsByIdAsync(int chainsawId);
    }
}
