namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Web.ViewModels.RepairServiceProduct;

    public interface IRepairServiceProductService
    {
        Task<string> CreateAndReturnIdAsync(RepairServiceProductFormModel formModel);
    }
}
