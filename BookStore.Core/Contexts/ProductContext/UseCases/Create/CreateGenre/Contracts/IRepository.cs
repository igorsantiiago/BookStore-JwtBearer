using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(string name, CancellationToken cancellationToken);
    Task SaveAsync(Genre genre, CancellationToken cancellationToken);
}
