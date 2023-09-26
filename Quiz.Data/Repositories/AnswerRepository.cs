using Quiz.Data.Data;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Data.Repositories
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        private readonly QuizDbContext _context;

        public AnswerRepository(QuizDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Answer answer)
        {
            _context.Answers.Update(answer);
        }
    }
}
