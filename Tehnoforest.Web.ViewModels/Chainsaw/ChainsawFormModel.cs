namespace Tehnoforest.Web.ViewModels.Chainsaw
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Product;
    using static Common.EntityValidationConstants.Chainsaw;

    public class ChainsawFormModel
    {
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PowerMin, PowerMax)]
        [Display(Name = "Мощност")]
        public decimal Power { get; set; }

        [Required]
        [Range(typeof(int), CylinderDisplacementMin, CylinderDisplacementMax)]
        [Display(Name = "Обем на цилиндъра")]
        public int CylinderDisplacement { get; set; }

        [Required]
        [Range(typeof(int), BarMin, BarMax)]
        [Display(Name = "Дължина на шина")]
        public int BarLength { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;


        [Required]
        [Range(typeof(decimal), PriceMin, PriceMax)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Range(typeof(int), AvailabilityMin, AvailabilityMax)]
        [Display(Name = "Цена")]
        public int Availability { get; set; }
    }
}
