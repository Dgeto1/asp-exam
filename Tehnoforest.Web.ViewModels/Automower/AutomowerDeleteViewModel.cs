namespace Tehnoforest.Web.ViewModels.Automower
{
    using System.ComponentModel.DataAnnotations;

    public class AutomowerDeleteViewModel
    {
        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Display(Name = "Наличност")]
        public int Availability { get; set; }

        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;
    }
}
