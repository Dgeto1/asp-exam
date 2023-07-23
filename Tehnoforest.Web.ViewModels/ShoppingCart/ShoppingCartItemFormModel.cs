namespace Tehnoforest.Web.ViewModels.ShoppingCart
{
    using System.ComponentModel.DataAnnotations;
    public class ShoppingCartItemFormModel
    {
        public int ShoppingCartItemId { get; set; }

        [Required]
        public string ShoppingCartId { get; set; } = null!;

        [Required]
        public int ProductId { get; set; }

        [Display(Name = "Продукт")]
        public string ProductName { get; set; } = null!;

        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        [DataType("Integer")]
        [Range(1, 100)]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [DataType("float")]
        public decimal? DiscountPcnt { get; set; }

        [Display(Name = "Финална цена")]
        [DataType(DataType.Currency)]
        public decimal Total => Math.Round(ProductPrice * (1 - (decimal)DiscountPcnt) * Quantity, 2);

        public string? ImageUrl { get; set; }
    }
}
