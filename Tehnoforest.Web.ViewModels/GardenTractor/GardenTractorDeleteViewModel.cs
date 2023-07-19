namespace Tehnoforest.Web.ViewModels.GardenTractor
{
    using System.ComponentModel.DataAnnotations;

    public class GardenTractorDeleteViewModel
    {
        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Display(Name = "Наличност")]
        public int Availability { get; set; }

        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;
    }
}
