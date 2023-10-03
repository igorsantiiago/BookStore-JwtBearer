using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateGenre.Contracts;

public interface IRepository
{
    Task<Genre?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken);
    Task SaveAsync(Genre genre, CancellationToken cancellationToken);
}
