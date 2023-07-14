namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Web.ViewModels.Chainsaw;

    public interface IChainsawService
    {
        Task<bool> ExistByModelAsync(string chainsawModel);

        Task CreateAsync(ChainsawFormModel formModel);
    }
}
