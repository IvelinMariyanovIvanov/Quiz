using Quiz.Models.Entities;

namespace Quiz.Data.Repositories.Interfaces
{
    public interface IAnswerRepository: IBaseRepository<Answer>
    {
        void Update(Answer answer);
    }
}
