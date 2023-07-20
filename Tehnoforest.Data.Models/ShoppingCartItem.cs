using System.ComponentModel.DataAnnotations;
using static Tehnoforest.Common.EntityValidationConstants;

namespace Tehnoforest.Data.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public string ShoppingCartId { get; set; } = null!;
        public int Quantity { get; set; }
        public int? AutomowerId { get; set; }
        public int? ChainsawId { get; set; }
        public int? GardenTractorId { get; set; }
        public int? GrassTrimmerId { get; set; }
        public int? LawnMowerId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }

        //public virtual Product Product { get; set; } = null!;
        public virtual Automower? Automower { get; set; }
        public virtual Chainsaw? Chainsaw { get; set; }
        public virtual GardenTractor? GardenTractor { get; set; }
        public virtual GrassTrimmer? GrassTrimmer { get; set; }
        public virtual LawnMower? LawnMower { get; set; }
    }
}
