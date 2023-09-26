using Quiz.Models.Entities;
using static Quiz.Helpers.Constants;

namespace Quiz.Web.ViewModels
{
    public class QuestionVM
    {

        public int Id { get; set; }

        public int RandomAuthorId { get; set; }
        public Author RandomAuthor { get; set; } = new Author();

        public QuestionType QuestionType { get; set; }

        public Quote AskedQuote { get; set; }
        public int QuoteId { get; set; }


        public Author FalseAuthor1 { get; set; }
        public int FalseAuthor1Id { get; set; }


        public Author FalseAuthor2 { get; set; }
        public int FalseAuthor2Id { get; set; }


        public Author CorrectAuthor { get; set; }
        public int CorrectAuthorId { get; set; }

        public List<Author> MultipleOptionAuthorList { get; set; } = new List<Author>();


    }
}
