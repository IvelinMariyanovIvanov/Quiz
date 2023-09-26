using Quiz.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Data.Repositories.Interfaces
{
    public interface IAnswerUserRepository: IBaseRepository<UserAnswers>
    {
        void Update(UserAnswers answerUser);
    }
}
