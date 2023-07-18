namespace Tehnoforest.Services.Data.Models.Automower
{
    using Tehnoforest.Web.ViewModels.Automower;

    public class AllAutomowersFilteredAndPagedServiceModel
    {
        public AllAutomowersFilteredAndPagedServiceModel()
        {
            this.Automowers = new HashSet<AutomowerAllViewModel>();
        }
        public int TotalAutomowersCount { get; set; }

        public IEnumerable<AutomowerAllViewModel> Automowers { get; set; }
    }
}
