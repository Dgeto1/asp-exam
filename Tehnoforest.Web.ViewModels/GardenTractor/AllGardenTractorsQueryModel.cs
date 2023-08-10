namespace Tehnoforest.Web.ViewModels.GardenTractor
{
    using System.ComponentModel.DataAnnotations;

    using Tehnoforest.Web.ViewModels.Enums;
    using static Tehnoforest.Common.GeneralApplicationConstants;
    public class AllGardenTractorsQueryModel
    {
        public AllGardenTractorsQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.GardenTractorsPerPage = EntitiesPerPage;

            this.GardenTractors = new HashSet<GardenTractorAllViewModel>();
        }

        [Display(Name = "Търси по дума")]
        public string? SearchString { get; set; }

        [Display(Name = "Сортирай по")]
        public ProductsSorting GardenTractorsSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Покажи по")]
        public int GardenTractorsPerPage { get; set; }

        public int TotalGardenTractor { get; set; }

        public IEnumerable<GardenTractorAllViewModel> GardenTractors { get; set; }
    }
}
