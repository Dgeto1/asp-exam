using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehnoforest.Data.Models
{
    public class Order
    {
        public Order()
        {
            UserId = Guid.NewGuid();
        }
        [Key]
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; } = null!;

        public List<OrderItem> OrderItems { get; set; } = null!;
    }
}
