using Tehnoforest.Web.ViewModels.RepairServiceProduct;

namespace Tehnoforest.Services.Data.Models.RepairServiceProduct
{
    public class AllRepairServiceProductsModel
    {
        public AllRepairServiceProductsModel()
        {
            this.Products = new HashSet<RepairServiceProductAllViewModel>();
        }
        public IEnumerable<RepairServiceProductAllViewModel> Products { get; set; }
    }
}
