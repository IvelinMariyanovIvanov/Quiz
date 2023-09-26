
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

        [ForeignKey(nameof(FalseAuthor1))]
        public int FalseAuthor1Id { get; set; }
        [NotMapped]
        public Author FalseAuthor1 { get; set; }

        [ForeignKey(nameof(FalseAuthor2))]
        public int FalseAuthor2Id { get; set;}
        [NotMapped]
        public Author FalseAuthor2 { get; set; }

        [ForeignKey(nameof(CorrectAuthorId))]
        public int CorrectAuthorId { get; set; }
        [NotMapped]
        public Author CorrectAuthor { get; set; }
    }
}
