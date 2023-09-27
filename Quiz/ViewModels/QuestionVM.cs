using Quiz.Models.Entities;
using static Quiz.Helpers.Constants;

namespace Quiz.Web.ViewModels
{
    public class QuestionVM
    {

        public int Id { get; set; }

        /// <summary>
        /// Option Author for yes or no
        /// </summary>
        public int OptionAuthorId { get; set; }
        public Author OptionAuthor { get; set; } = new Author();

        public QuestionType QuestionType { get; set; }

        public Quote AskedQuote { get; set; }
        public int QuoteId { get; set; }


        public Author FalseAuthor1 { get; set; }
        public int FalseAuthor1Id { get; set; }


        public Author FalseAuthor2 { get; set; }
        public int FalseAuthor2Id { get; set; }


        public Author CorrectAuthor { get; set; }
        public int CorrectAuthorId { get; set; }

  
        public int SelectedAuthorId { get; set; }
        public List<Author> MultipleOptionAuthorList { get; set; } = new List<Author>();

        public bool ShowAnswersOptions { get; set; } = true;
        public bool ShowNextButton { get; set; } = false;
        public int NextQuestionId { get; set; }
    }
}
