using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tehnoforest.Web.ViewModels.GardenTractor
{
    public  class GardenTractorAllViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Display(Name = "Обем на цилиндъра")]
        public decimal CylinderDisplacement { get; set; }

        [Display(Name = "Ефективна мощност при зададени обороти Енергия")]
        public decimal NetPower { get; set; }

        [Display(Name = "Ширина на косене")]
        public int CuttingWidth { get; set; }

        [Display(Name = "Максимална височина на косене")]
        public int CuttingHeightMax { get; set; }

        [Display(Name = "Минимална височина на косене")]
        public int CuttingHeightMin { get; set; }

        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
