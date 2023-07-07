namespace Tehnoforest.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();

            this.Automowers = new HashSet<Automower>();
            this.Chainsaws = new HashSet<Chainsaw>();
            this.GardenTractors = new HashSet<GardenTractor>();
            this.GrassTrimmers = new HashSet<GrassTrimmer>();
            this.LawnMowers = new HashSet<LawnMower>();
        }

        [NotMapped]
        public virtual ICollection<Automower> Automowers { get; set; }

        [NotMapped]
        public virtual ICollection<Chainsaw> Chainsaws { get; set; }

        [NotMapped]
        public virtual ICollection<GardenTractor> GardenTractors { get; set; }

        [NotMapped]
        public virtual ICollection<GrassTrimmer> GrassTrimmers { get; set; }

        [NotMapped]
        public virtual ICollection<LawnMower> LawnMowers { get; set; }
    }
}