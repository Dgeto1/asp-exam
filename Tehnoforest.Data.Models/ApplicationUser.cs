﻿namespace Tehnoforest.Data.Models
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
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [NotMapped]
        public virtual ICollection<Product> Products { get; set; }
    }
}