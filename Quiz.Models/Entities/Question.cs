
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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


        [ForeignKey(nameof(FalseAuthor1Id))]
        public Author FalseAuthor1 { get; set; }
        public int FalseAuthor1Id { get; set; }


        [ForeignKey(nameof(FalseAuthor2Id))]
        public Author FalseAuthor2 { get; set; }
        public int FalseAuthor2Id { get; set;}


        [ForeignKey(nameof(CorrectAuthorId))]
        public Author CorrectAuthor { get; set; }
        public int CorrectAuthorId { get; set; }

        [ForeignKey(nameof(OptionAuthorId))]
        public Author OptionAuthor { get; set; }
        public int OptionAuthorId { get; set; }

    }
}
