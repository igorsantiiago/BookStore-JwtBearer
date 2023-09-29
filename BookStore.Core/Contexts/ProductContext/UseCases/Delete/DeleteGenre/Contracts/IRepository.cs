using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteGenre.Contracts;

public interface IRepository
{
    Task<Genre> GetGenreAsync(Guid id, CancellationToken cancellationToken);
    Task RemoveGenreAsync(Genre genre, CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}
