namespace Tehnoforest.Web.ViewModels.Automower
{
    using System.ComponentModel.DataAnnotations;

    public  class AutomowerDetailsViewModel : AutomowerAllViewModel
    {
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Вид на ограничението")]
        public string BoundaryType { get; set; } = null!;
    }
}
