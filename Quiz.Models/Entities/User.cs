using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNet.Identity.EntityFramework;

namespace Quiz.Models.Entities
{
    public class User: IdentityUser
    {
        [Required]
        public string FullName { get; set; }
    }
}
