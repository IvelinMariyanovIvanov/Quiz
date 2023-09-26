﻿
namespace Quiz.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IQuoteRepository QuoteRepository { get; }
        IQuestionRepository QuestionRepository { get; }

        Task SaveAsync();
    }
}
