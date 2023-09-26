using System.ComponentModel.DataAnnotations;

namespace Quiz.Web.ViewModels
{
    public class LogInUserVM
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string ErrorMessage { get; set; }
    }
}
