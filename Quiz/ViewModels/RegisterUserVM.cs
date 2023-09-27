using System.ComponentModel.DataAnnotations;

namespace Quiz.Web.ViewModels
{
    public class RegisterUserVM : CreateUserVM
    {
        public string ErrorMessage { get; set; }
    }
}
