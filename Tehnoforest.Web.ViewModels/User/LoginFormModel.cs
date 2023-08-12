namespace Tehnoforest.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    public class LoginFormModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
