using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UseCases.Create.CreateAuthor;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> AnyAsync(string firstName, string lastName, CancellationToken cancellationToken)
        => await _context.Authors.AsNoTracking()
        .AnyAsync(author => author.Name.FirstName == firstName && author.Name.LastName == lastName, cancellationToken: cancellationToken);

    public async Task SaveAsync(Author author, CancellationToken cancellationToken)
    {
        await _context.Authors.AddAsync(author, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
