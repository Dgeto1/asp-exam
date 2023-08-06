namespace Tehnoforest.Data.Models
{
    using Microsoft.AspNetCore.Identity;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

    using static Tehnoforest.Common.EntityValidationConstants.User;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();

            Products = new HashSet<Product>();
            RepairServiceProducts = new HashSet<RepairServiceProduct>();
            Orders = new HashSet<Order>();
            //ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [NotMapped]
        public virtual ICollection<Product> Products { get; set; }

        [NotMapped]
        public virtual ICollection<RepairServiceProduct> RepairServiceProducts { get; set; }

        [NotMapped]
        public virtual ICollection<Order> Orders { get; set; }

        //[NotMapped]
       // public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}