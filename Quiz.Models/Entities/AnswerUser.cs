
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models.Entities
{
    public class AnswerUser
    {
        public int AnswerId { get; set; }
        
        public string UserId { get; set; }
    }
}
