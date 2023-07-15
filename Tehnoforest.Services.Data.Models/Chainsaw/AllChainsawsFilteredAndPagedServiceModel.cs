namespace Tehnoforest.Services.Data.Models.Chainsaw
{
    using Tehnoforest.Web.ViewModels.Chainsaw;

    public class AllChainsawsFilteredAndPagedServiceModel
    {
        public AllChainsawsFilteredAndPagedServiceModel()
        {
            this.Chainsaws = new HashSet<ChainsawAllViewModel>();
        }

        public int TotalChainsawsCount { get; set; }

        public IEnumerable<ChainsawAllViewModel> Chainsaws { get; set; }
    }
}
