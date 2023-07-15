namespace Tehnoforest.Web.ViewModels.Chainsaw
{
    using System.ComponentModel.DataAnnotations;

    public class ChainsawAllViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Display(Name = "Обем на цилиндъра")]
        public decimal CylinderDisplacement { get; set; }

        [Display(Name = "Мощност")]
        public decimal Power { get; set; }

        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
