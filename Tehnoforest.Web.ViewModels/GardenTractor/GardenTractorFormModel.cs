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
        [Range(typeof(int), NetPowerMin, NetPowerMax)]
        public int NetPower { get; set; }

        [Required]
        [Display(Name = "Вид на ограничението")]
        public string BoundaryType { get; set; } = null!;

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
    }
}
