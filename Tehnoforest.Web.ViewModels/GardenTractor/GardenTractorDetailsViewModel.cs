using System.ComponentModel.DataAnnotations;

namespace Tehnoforest.Web.ViewModels.GardenTractor
{
    public class GardenTractorDetailsViewModel : GardenTractorAllViewModel
    {
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;
    }
}
