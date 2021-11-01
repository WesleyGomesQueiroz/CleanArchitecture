using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.WebUI.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password don´t match")]
        public string ConfirmPassword { get; set; }
    }
}
