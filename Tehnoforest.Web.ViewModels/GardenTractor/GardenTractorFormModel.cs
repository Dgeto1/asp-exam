namespace Tehnoforest.Web.ViewModels.GardenTractor
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Product;
    using static Common.EntityValidationConstants.GardenTractor;

    public  class GardenTractorFormModel
    {
        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Required]
        [Range(typeof(int), CylinderDisplacementMin, CylinderDisplacementMax)]
        [Display(Name = "Обем на цилиндъра")]
        public int CylinderDisplacement { get; set; }

        [Required]
        [Range(typeof(decimal), NetPowerMin, NetPowerMax)]
        [Display(Name = "Ефективна мощност при зададени обороти Енергия")]
        public decimal NetPower { get; set; }

        [Required]
        [Range(typeof(int), CuttingWidthMin, CuttingWidthMax)]
        [Display(Name = "Ширина на косене")]
        public int CuttingWidth { get; set; }

        [Required]
        [Range(typeof(int), CuttingHeightMaxMin, CuttingHeightMaxMax)]
        [Display(Name = "Максимална височина на косене")]
        public int CuttingHeightMax { get; set; }

        [Required]
        [Range(typeof(int), CuttingHeightMinMin, CuttingHeightMinMax)]
        [Display(Name = "Минимална височина на косене")]
        public int CuttingHeightMin { get; set; } 

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Описание на продукт")]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMin, PriceMax)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(int), AvailabilityMin, AvailabilityMax)]
        [Display(Name = "Наличност")]
        public int Availability { get; set; }
    }
}
