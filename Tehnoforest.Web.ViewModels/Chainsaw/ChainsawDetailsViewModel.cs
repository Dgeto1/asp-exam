using System.ComponentModel.DataAnnotations;

namespace Tehnoforest.Web.ViewModels.Chainsaw
{
    public class ChainsawDetailsViewModel : ChainsawAllViewModel
    {
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;
    }
}
