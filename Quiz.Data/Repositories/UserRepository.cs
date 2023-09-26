
using Quiz.Data.Data;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Models.Entities;

namespace Quiz.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly QuizDbContext _context;

        public UserRepository(QuizDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
