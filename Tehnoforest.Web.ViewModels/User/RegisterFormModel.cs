namespace Tehnoforest.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    using static Tehnoforest.Common.EntityValidationConstants.User;

    public class RegisterFormModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "Паролата {0} тряба да бъде поне {2} и максимално {1} символа дълга.")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
