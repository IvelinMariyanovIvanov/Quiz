using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
//using Microsoft.AspNet.Identity.EntityFramework;

namespace Quiz.Models.Entities
{
    public class User: IdentityUser
    {
        [Required]
        public string FullName { get; set; }

        [JsonIgnore]
        public ICollection<UserAnswers> AnswerUsers { get; set; }
    }
}
