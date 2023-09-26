
using Quiz.Models.Entities;

namespace Quiz.Data.Repositories.Interfaces
{
    public interface IQuestionRepository: IBaseRepository<Question>
    {
        void Update(Question question);
    }
}
