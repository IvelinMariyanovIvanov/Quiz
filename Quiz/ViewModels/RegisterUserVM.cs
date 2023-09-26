using System.ComponentModel.DataAnnotations;

namespace Quiz.Web.ViewModels
{
    public class RegisterUserVM
    {
        [Required]
        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }

        public string ErrorMessage { get; set; }
    }
}
