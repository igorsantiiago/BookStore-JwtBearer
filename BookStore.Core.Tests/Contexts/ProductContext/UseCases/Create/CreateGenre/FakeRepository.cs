using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre.Contracts;

namespace BookStore.Core.Tests.Contexts.ProductContext.UseCases.Create.CreateGenre;

public class FakeRepository : IRepository
{
    private static readonly Genre _genre = new("Ficção Cientifica");

    public Task<bool> AnyAsync(string name, CancellationToken cancellationToken)
    {
        if (name == _genre.Name)
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    public Task SaveAsync(Genre genre, CancellationToken cancellationToken)
    {
        if(genre == null)
            return Task.FromResult(false);

        return Task.FromResult(true);
    }
}
