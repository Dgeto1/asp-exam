using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Tehnoforest.Common.EntityValidationConstants.Product;
using static Tehnoforest.Common.EntityValidationConstants.RepairService;

namespace Tehnoforest.Data.Models
{
    public class RepairServiceProduct
    {
        public RepairServiceProduct()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [MaxLength(ClientNameMaxLength)]
        public string ClientName { get; set; } = null!;

        [MaxLength(BrandNameMaxLength)]
        public string BrandMachine { get; set; } = null!;

        [MaxLength(ModelMaxLength)]
        public string ModelMachine { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string ProblemDescription { get; set; } = null!;

        public DateTime DateOfAcceptance { get; set; }

        public DateTime DateOfReturning { get; set; }

        [NotMapped]
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid? UserId { get; set; }

        public ApplicationUser? User { get; set; } = null!;
    }
}
