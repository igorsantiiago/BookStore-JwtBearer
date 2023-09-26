using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.SharedContext.ValueObjects;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(string title, Author author, CancellationToken cancellationToken);
    Task<Author?> GetAuthor(Guid id, CancellationToken cancellationToken);
    Task<Genre?> GetGenre(Guid id, CancellationToken cancellationToken);
    Task<Publisher?> GetPublisher(Guid id, CancellationToken cancellationToken);
    Task SaveAsync(Book book, CancellationToken cancellationToken);
}
