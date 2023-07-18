namespace Tehnoforest.Web.ViewModels.Automower
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Product;
    using static Common.EntityValidationConstants.Automower;
    public  class AutomowerFormModel
    {
        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Required]
        [Range(typeof(int), WorkingAreaCapacityMin, WorkingAreaCapacityMax)]
        [Display(Name = "Работна площ")]
        public int WorkingAreaCapacity { get; set; }

        [Required]
        [Range(typeof(int), MaximumSlopePerformanceMin, MaximumSlopePerformanceMax)]
        public int SlopePerformance { get; set; }

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

        [Required]
        [Range(typeof(int), AvailabilityMin, AvailabilityMax)]
        [Display(Name = "Наличност")]
        public int Availability { get; set; }
    }
}
