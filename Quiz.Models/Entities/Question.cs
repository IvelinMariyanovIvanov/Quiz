
using System.ComponentModel.DataAnnotations;
using static Quiz.Helpers.Constants;

namespace Quiz.Models.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public  QuestionType QuestionType { get;set; }

        public Quote AskedQuote { get; set; }

        // navigation properties
        public List<Quote> Quotes { get; set; }
        public Quote CorrectQuote { get; set; }

        //[Required]
        //[MinLength(5)]
        //public string Title { get; set; }

        //[Required]
        //[MinLength(10)]
        //public string Body { get; set; }
    }
}
