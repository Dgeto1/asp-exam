namespace Tehnoforest.Services.Data.Models.GardenTractor
{
    using Tehnoforest.Web.ViewModels.GardenTractor;
    public class AllGardenTractorsFilteredAndPagedServiceModel
    {
        public AllGardenTractorsFilteredAndPagedServiceModel()
        {
            this.GardenTractors = new HashSet<GardenTractorAllViewModel>();
        }
        public int TotalGardenTractosrsCount { get; set; }

        public IEnumerable<GardenTractorAllViewModel> GardenTractors { get; set; }
    }
}
