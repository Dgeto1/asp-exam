namespace Tehnoforest.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Product;
    public class Chainsaw
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        public decimal Power {get; set;}

        [Required]
        public int CylinderDisplacement { get; set; }

        [Required]
        public int BarLength { get; set; }

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

        [NotMapped]
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid? UserId { get; set; }

        public ApplicationUser? User { get; set; } = null!;
    }
}
