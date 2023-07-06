namespace Tehnoforest.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Product;
    public class LawnMower
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        public string DriveSystem { get; set; } = null!;

        [Required]
        public int WorkingAreaCapacity { get; set; }

        [Required]
        public int CuttingWidth { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal RentalPrice { get; set; }

        [Required]
        public int Availability { get; set; }

        [Required]
        public int RentalavAilability { get; set; }

    }
}
