using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tehnoforest.Web.ViewModels.GrassTrimmer
{
    public class GrassTrimmerAllViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Display(Name = "Мощност")]
        public decimal Power { get; set; }

        [Display(Name = "Ширина на косене")]
        public int CuttingWidth { get; set; }

        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
