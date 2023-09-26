
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Models.Entities
{
    public class UserAnswers
    {
        public int AnswerId { get; set; }

        [ForeignKey(nameof(AnswerId))]
        public Answer Answer { get; set; }
        
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
