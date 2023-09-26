
using Quiz.Models.Entities;

namespace Quiz.Data.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        void Update(User user);
    }
}
