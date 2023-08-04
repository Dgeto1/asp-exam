using System.ComponentModel.DataAnnotations;

namespace Tehnoforest.Web.ViewModels.RepairServiceProduct
{
    public class RepairServiceProductDetailsViewModel : RepairServiceProductAllViewModel
    {
        [Display(Name = "Описание на проблем")]
        public string ProblemDescription { get; set; } = null!;

        [Display(Name = "Дата на приемане")]
        public DateTime DateOfAcceptance { get; set; }
    }
}
