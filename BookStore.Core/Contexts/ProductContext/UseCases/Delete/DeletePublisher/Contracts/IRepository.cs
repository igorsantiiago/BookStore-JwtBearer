using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeletePublisher.Contracts;

public interface IRepository
{
    Task<Publisher?> GetPublisherAsync(Guid id, CancellationToken cancellationToken);
    void RemovePublisher(Publisher publisher, CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}
