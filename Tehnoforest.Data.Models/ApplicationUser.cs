namespace Tehnoforest.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();

            Products = new HashSet<Product>();
        }

        [NotMapped]
        public virtual ICollection<Product> Products { get; set; }
    }
}