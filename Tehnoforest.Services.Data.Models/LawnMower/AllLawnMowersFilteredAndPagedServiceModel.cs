using Tehnoforest.Web.ViewModels.Automower;
using Tehnoforest.Web.ViewModels.LawnMower;

namespace Tehnoforest.Services.Data.Models.LawnMower
{
    public class AllLawnMowersFilteredAndPagedServiceModel
    {
        public AllLawnMowersFilteredAndPagedServiceModel()
        {
            this.LawnMowers = new HashSet<LawnMowerAllViewModel>();
        }
        public int TotalLawnMowersCount { get; set; }

        public IEnumerable<LawnMowerAllViewModel> LawnMowers { get; set; }
    }
}
