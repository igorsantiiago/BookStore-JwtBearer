using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(string title, Author author, CancellationToken cancellationToken);
    Task<Author> GetAuthor(Guid id);
    Task<Genre> GetGenre(Guid id);
    Task<Publisher> GetPublisher(Guid id);
    Task SaveAsync(Book book, CancellationToken cancellationToken);
}
