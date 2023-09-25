
using Quiz.Models.Entities;

namespace Quiz.Data.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        void Update(Author author);
    }
}
