using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tehnoforest.Web.ViewModels.GrassTrimmer
{
    public class GrassTrimmerDetailsViewModel : GrassTrimmerAllViewModel
    {
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;

        
    }
}
