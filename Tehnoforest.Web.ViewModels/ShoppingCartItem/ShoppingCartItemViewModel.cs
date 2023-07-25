namespace Tehnoforest.Web.ViewModels.ShoppingCartItem
{
    using System.ComponentModel.DataAnnotations;

    public class ShoppingCartItemViewModel
    {
        public int ShoppingCartItemId { get; set; }

        [Required]
        public string ShoppingCartId { get; set; } = null!;

        [Required]
        public int ProductId { get; set; }

        [Display(Name = "Продукт")]
        public string ProductModel { get; set; } = null!;

        [Display(Name = "Цена")]
        public decimal ProductPrice { get; set; }

        [DataType("Integer")]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Линк на изображение")]
        public string ProductImageUrl { get; set; } = null!;
    }
}
