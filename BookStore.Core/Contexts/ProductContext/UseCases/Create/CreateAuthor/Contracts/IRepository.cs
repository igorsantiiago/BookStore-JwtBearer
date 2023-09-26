using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(string firstName, string lastName, CancellationToken cancellationToken);
    Task SaveAsync(Author author, CancellationToken cancellationToken);
}
