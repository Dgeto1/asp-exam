namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Services.Data.Models.Automower;
    using Tehnoforest.Services.Data.Models.RepairServiceProduct;
    using Tehnoforest.Web.ViewModels.Automower;
    using Tehnoforest.Web.ViewModels.RepairServiceProduct;

    public interface IRepairServiceProductService
    {
        Task<string> CreateAndReturnIdAsync(RepairServiceProductFormModel formModel);

        Task<RepairServiceProductDetailsViewModel> GetDetailsByIdAsync(string productId);

        Task<AllRepairServiceProductsModel> AllAsync(AllRepairServiceProductsQueryModel queryModel);

         Task<bool> ExistsByIdAsync(string id);
    }
}
