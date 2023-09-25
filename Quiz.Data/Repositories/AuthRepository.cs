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
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly QuizDbContext _quizDbContext;

        public AuthorRepository(QuizDbContext context) : base(context)
        {
            _quizDbContext = context;
        }

        public void Update(Author author)
        {
            _quizDbContext.Update(author);
        }
    }
}
