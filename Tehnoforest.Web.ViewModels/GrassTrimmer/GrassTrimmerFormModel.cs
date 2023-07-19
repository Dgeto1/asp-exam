namespace Tehnoforest.Web.ViewModels.GrassTrimer
{
    using System.ComponentModel.DataAnnotations;

    using static Tehnoforest.Common.EntityValidationConstants.Product;
    using static Tehnoforest.Common.EntityValidationConstants.GrassTrimmer;

    public  class GrassTrimmerFormModel
    {
        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PowerMin, PowerMax)]
        [Display(Name = "Мощност")]
        public decimal Power { get; set; }

        [Required]
        [Range(typeof(int), CuttingWidthMin, CuttingWidthMax)]
        [Display(Name = "Ширина на косене")]
        public int CuttingWidth { get; set; }

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
