﻿using System.ComponentModel.DataAnnotations;

namespace Tehnoforest.Data.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; } = null!;
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; } = null!;
    }
}
