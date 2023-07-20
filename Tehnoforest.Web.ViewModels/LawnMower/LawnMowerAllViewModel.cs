namespace Tehnoforest.Web.ViewModels.LawnMower
{
    using System.ComponentModel.DataAnnotations;

    public class LawnMowerAllViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Display(Name = "Максимална работна площ")]
        public int WorkingAreaCapacity { get; set; }

        [Display(Name = "Задвижваща система")]
        public string DriveSystem { get; set; } = null!;

        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
