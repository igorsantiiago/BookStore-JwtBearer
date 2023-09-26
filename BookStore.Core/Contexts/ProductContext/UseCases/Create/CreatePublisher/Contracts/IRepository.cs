using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(string name, CancellationToken cancellationToken);
    Task SaveAsync(Publisher publisher, CancellationToken cancellationToken);
}
