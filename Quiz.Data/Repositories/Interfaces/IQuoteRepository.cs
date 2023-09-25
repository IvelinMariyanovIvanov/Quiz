
using Quiz.Models.Entities;

namespace Quiz.Data.Repositories.Interfaces
{
    public interface IQuoteRepository: IBaseRepository<Quote>
    {
        void Update(Quote quote);
    }
}
