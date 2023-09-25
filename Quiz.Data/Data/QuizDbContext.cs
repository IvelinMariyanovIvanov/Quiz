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

            // Seed Authors Table
            builder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Albert Einstein" },
                new Author { Id = 2, Name = "Buddha" },
                new Author { Id = 3, Name = "Dalai Lama" },
                new Author { Id = 4, Name = "Elon Musk" },
                new Author { Id = 5, Name = "Freddie Mercury" },
                new Author { Id = 6, Name = "Michelle Obama" }
            );

            // Seed Quotes
            builder.Entity<Quote>().HasData(
                new Quote { Id = 1, AuthorId = 1, Text= "Learn from yesterday, live for today, hope for tomorrow. The important thing is not to stop questioning." },
                new Quote { Id = 2, AuthorId = 1, Text = "We cannot solve our problems with the same thinking we used when we created them." },
                new Quote { Id = 3, AuthorId = 1, Text = "Life is like riding a bicycle. To keep your balance, you must keep moving." },
                new Quote { Id = 4, AuthorId = 2, Text = "Do not dwell in the past, do not dream of the future, concentrate the mind on the present moment." },
                new Quote { Id = 5, AuthorId = 2, Text = "Three things cannot be long hidden: the sun, the moon, and the truth." },
                new Quote { Id = 6, AuthorId = 2, Text = "You will not be punished for your anger, you will be punished by your anger." },
                new Quote { Id = 7, AuthorId = 3, Text = "In order to carry a positive action we must develop here a positive vision." },
                new Quote { Id = 8, AuthorId = 3, Text = "Be kind whenever possible. It is always possible." },
                new Quote { Id = 9, AuthorId = 3, Text = "Be kind whenever possible. It is always possible." }
            );

        }
    }
}
