using System.ComponentModel.DataAnnotations;

namespace Tehnoforest.Web.ViewModels.GrassTrimmer
{
    public class GrassTrimmerDeleteViewModel
    {
        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Display(Name = "Наличност")]
        public int Availability { get; set; }

        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;
    }
}
