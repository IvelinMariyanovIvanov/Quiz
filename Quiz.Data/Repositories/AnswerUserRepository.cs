
using Quiz.Data.Data;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Models.Entities;

namespace Quiz.Data.Repositories
{
    public class AnswerUserRepository : BaseRepository<UserAnswers>, IAnswerUserRepository
    {
        private readonly QuizDbContext _context;

        public AnswerUserRepository(QuizDbContext context) : base(context)
        {

        }

        public void Update(UserAnswers answerUser)
        {
            throw new NotImplementedException();
        }
    }
}
