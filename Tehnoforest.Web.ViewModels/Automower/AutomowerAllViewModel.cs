namespace Tehnoforest.Web.ViewModels.Automower
{
    using System.ComponentModel.DataAnnotations;

    public class AutomowerAllViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Display(Name = "Максимална работна площ")]
        public int WorkingAreaCapacity { get; set; }

        [Display(Name = "Максимален наклон на работа")]
        public int MaximumSlopePerformance { get; set; }

        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
