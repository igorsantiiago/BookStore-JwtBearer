using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Contracts;

namespace BookStore.Core.Tests.Contexts.ProductContext.UseCases.Create.CreatePublisher;

public class FakeRepository : IRepository
{
    private readonly Publisher _publisher = new("DarkSide");
    public Task<bool> AnyAsync(string name, CancellationToken cancellationToken)
    {
        if (name == _publisher.Name)
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    public Task SaveAsync(Publisher publisher, CancellationToken cancellationToken)
    {
        if(_publisher == null)
            return Task.FromResult(false);

        return Task.FromResult(true);
    }
}
