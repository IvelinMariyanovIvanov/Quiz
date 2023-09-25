using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quiz.Models.Entities;

namespace Quiz.Data.Data
{
    public class QuizDbContext : IdentityDbContext<User>
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed OrderStatus Table
            builder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Albert Einstein" },
                new Author { Id = 2, Name = "Buddha" },
                new Author { Id = 3, Name = "Dalai Lama" },
                new Author { Id = 4, Name = "Elon Musk" },
                new Author { Id = 5, Name = "Freddie Mercury" },
                new Author { Id = 6, Name = "Michelle Obama" }
            );
        }
    }
}
