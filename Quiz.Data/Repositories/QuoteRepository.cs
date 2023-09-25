
using Quiz.Data.Data;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Models.Entities;

namespace Quiz.Data.Repositories
{
    public class QuoteRepository : BaseRepository<Quote>, IQuoteRepository
    {
        private readonly QuizDbContext _quizDbContext;

        public QuoteRepository(QuizDbContext context) : base(context)
        {
            _quizDbContext = context;
        }

        public void Update(Quote quote)
        {
            _quizDbContext.Quotes.Update(quote);
        }
    }
}
