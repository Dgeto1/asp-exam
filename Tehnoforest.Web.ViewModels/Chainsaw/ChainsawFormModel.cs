namespace Tehnoforest.Web.ViewModels.Chainsaw
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.InteropServices;
    using static Common.EntityValidationConstants.Product;
    public class ChainsawFormModel
    {
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PowerMin, PowerMax)]
        public decimal Power { get; set; }

        [Required]
        [Range(typeof(int), CylinderDisplacementMin, CylinderDisplacementMax)]
        [Display(Name = "Cylinder Displacement")]
        public int CylinderDisplacement { get; set; }

        [Required]
        [Range(typeof(int), BarMin, BarMax)]
        [Display(Name = "Bar Length")]
        public int BarLength { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;


        [Required]
        [Range(typeof(decimal), PriceMin, PriceMax)]
        [Display(Name = "Price Chainsaw")]
        public decimal Price { get; set; }
    }
}
