using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tehnoforest.Web.ViewModels.LawnMower
{
    public class LawnMowerDetailsViewModel : LawnMowerAllViewModel
    {
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Ширина на косене")]
        public int CuttingWidth { get; set; }
    }
}
