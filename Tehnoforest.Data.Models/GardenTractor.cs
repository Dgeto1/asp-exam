namespace Tehnoforest.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Product;
    public class GardenTractor
    {
        public GardenTractor()
        {
            this.ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        public int CylinderDisplacement { get; set; }

        [Required]
        public decimal NetPower { get; set; }

        [Required]
        public int CuttingWidth { get; set; }

        [Required]
        public int CuttingHeightMax { get; set; }

        [Required]
        public int CuttingHeightMin { get; set; }

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

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
