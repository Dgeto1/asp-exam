namespace Tehnoforest.Web.ViewModels.RepairServiceProduct
{
    using System.ComponentModel.DataAnnotations;
    using static Tehnoforest.Common.EntityValidationConstants.Product;
    using static Tehnoforest.Common.EntityValidationConstants.RepairService;
    public class RepairServiceProductFormModel
    {
        [Required]
        [StringLength(ClientNameMaxLength, MinimumLength = ClientNameMinLength)]
        [Display(Name = "Име на клиент")]
        public string ClientName { get; set; } = null!;

        [Required]
        [StringLength(BrandNameMaxLength, MinimumLength = BrandNameMinLength)]
        [Display(Name = "Марка на машината")]
        public string BrandMachine { get; set; } = null!;

        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        [Display(Name = "Модел на машината")]
        public string ModelMachine { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Описание на проблема")]
        public string ProblemDescription { get; set; } = null!;

        [Required]
        [Display(Name = "Дата на приемане")]
        public DateTime DateOfAcceptance { get; set; }

        [Required]
        [Display(Name = "Дата на връщане")]
        public DateTime DateOfReturning { get; set; }

    }
}
