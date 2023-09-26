
using Quiz.Data.Data;
using Quiz.Data.Repositories.Interfaces;

namespace Quiz.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizDbContext _quizDbContext;
        public IAuthorRepository AuthorRepository { get; private set; }
        public IQuoteRepository QuoteRepository { get; private set; }
        public IQuestionRepository QuestionRepository { get;private set; }

        public UnitOfWork(QuizDbContext quizDbContext)
        {
            _quizDbContext = quizDbContext;
            AuthorRepository = new AuthorRepository(quizDbContext);
            QuoteRepository = new QuoteRepository(quizDbContext);
            QuestionRepository = new QuestionRepository(quizDbContext);
        }

        public async Task SaveAsync()
        {
           await _quizDbContext.SaveChangesAsync();
        }
    }
}
