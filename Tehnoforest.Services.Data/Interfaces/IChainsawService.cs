using Tehnoforest.Web.ViewModels.Chainsaw;

namespace Tehnoforest.Services.Data.Interfaces
{
    public interface IChainsawService
    {
        Task<bool> ExistByModelAsync(string chainsawModel);

        Task CreateAsync(ChainsawFormModel formModel);
    }
}
