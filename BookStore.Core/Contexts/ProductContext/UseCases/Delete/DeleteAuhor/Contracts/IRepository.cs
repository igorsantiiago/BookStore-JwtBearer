using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteAuhor.Contracts;

public interface IRepository
{
    Task<Author?> GetAuthorAsync(Guid id, CancellationToken cancellationToken);
    void RemoveAuthor(Author author, CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}
