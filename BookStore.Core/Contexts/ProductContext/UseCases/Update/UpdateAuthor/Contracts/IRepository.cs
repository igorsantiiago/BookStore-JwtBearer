using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateAuthor.Contracts;

public interface IRepository
{
    Task<Author?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken);
    Task SaveAsync(Author author, CancellationToken cancellationToken);
}
