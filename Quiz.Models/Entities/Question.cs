
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Quiz.Helpers.Constants;

namespace Quiz.Models.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public  QuestionType QuestionType { get;set; }

        [ForeignKey(nameof(QuoteId))]
        public Quote AskedQuote { get; set; }
        public int QuoteId { get; set; }

        // navigation properties
        public List<Author> PossibleAnswers { get; set; }
        public Author CorrectAnswer { get; set; }

    }
}
