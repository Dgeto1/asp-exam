using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tehnoforest.Web.ViewModels.LawnMower
{
    public class LawnMowerDeleteViewModel
    {
        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Display(Name = "Наличност")]
        public int Availability { get; set; }

        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;
    }
}
