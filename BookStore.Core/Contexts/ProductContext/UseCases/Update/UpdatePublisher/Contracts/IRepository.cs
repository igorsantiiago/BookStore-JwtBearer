using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdatePublisher.Contracts;

public interface IRepository
{
    Task<Publisher?> GetPublisherByIdAsync(Guid id, CancellationToken cancellationToken);
    Task SaveAsync(Publisher publisher, CancellationToken cancellationToken);
}
