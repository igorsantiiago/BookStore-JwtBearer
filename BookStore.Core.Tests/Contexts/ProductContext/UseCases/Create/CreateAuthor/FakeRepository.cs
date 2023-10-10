using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Contracts;
using BookStore.Core.Contexts.SharedContext.ValueObjects;

namespace BookStore.Core.Tests.Contexts.ProductContext.UseCases.Create.CreateAuthor;

public class FakeRepository : IRepository
{
    private static readonly Name _name = new("Andre", "Baltieri");
    private static readonly Author _author = new(_name, DateTime.Now);
    public Task<bool> AnyAsync(string firstName, string lastName, CancellationToken cancellationToken)
    {
        if(firstName == _author.Name.FirstName && lastName == _author.Name.LastName)
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    public Task SaveAsync(Author author, CancellationToken cancellationToken)
    {
        if(author == null) 
            return Task.FromResult(false);

        return Task.FromResult(true);
    }
}
