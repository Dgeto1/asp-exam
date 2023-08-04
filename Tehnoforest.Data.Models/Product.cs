namespace Tehnoforest.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using static Tehnoforest.Common.EntityValidationConstants.Product;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; } = null!;

        public int? WorkingAreaCapacity { get; set; }

        public int? MaximumSlopePerformance { get; set; }

        public string? BoundaryType { get; set; } = null!;

        public decimal? Power { get; set; }

        public decimal? CylinderDisplacement { get; set; }

        public int? BarLength { get; set; }

        public decimal? NetPower { get; set; }

        public int? CuttingWidth { get; set; }

        public int? CuttingHeightMax { get; set; }

        public int? CuttingHeightMin { get; set; }

        public string? DriveSystem { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;


        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Availability { get; set; }

        public bool IsAvailable { get; set; }

        [NotMapped]
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid? UserId { get; set; }

        public ApplicationUser? User { get; set; } = null!;

    }
}
