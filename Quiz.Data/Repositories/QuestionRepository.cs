using Quiz.Data.Data;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Models.Entities;

namespace Quiz.Data.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        private readonly QuizDbContext _quizDbContext;

        public QuestionRepository(QuizDbContext context) : base(context)
        {
            _quizDbContext = context;
        }

        public void Update(Question question)
        {
            _quizDbContext.Update(question);
        }
    }
}
