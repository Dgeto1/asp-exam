namespace Tehnoforest.Services.Data.Models.GardenTractor
{
    using Tehnoforest.Web.ViewModels.GardenTractor;
    public class AllGardenTractorFilteredAndPagedServiceModel
    {
        public AllGardenTractorFilteredAndPagedServiceModel()
        {
            this.GardenTractors = new HashSet<GardenTractorAllViewModel>();
        }
        public int TotalGardenTractosrsCount { get; set; }

        public IEnumerable<GardenTractorAllViewModel> GardenTractors { get; set; }
    }
}
