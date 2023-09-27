using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Models.Entities
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AnswerText { get; set; } // Athor Name

        public bool IsCorrect { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        [ForeignKey(nameof(QuoteId))]
        public Quote Quote { get; set; }
        public int QuoteId { get; set; }

        [ForeignKey(nameof(AnswerId))]
        public Author AnswerAuthor { get; set; }
        public int AnswerId { get; set; }

        public ICollection<UserAnswers> AnswerUsers { get; set; }
    }
}
