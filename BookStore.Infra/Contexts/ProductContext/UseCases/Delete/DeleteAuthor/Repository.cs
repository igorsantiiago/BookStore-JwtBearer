using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteAuhor.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UseCases.Delete.DeleteAuthor;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
        => _context = context;
    public async Task<Author?> GetAuthorAsync(Guid id, CancellationToken cancellationToken)
         => await _context.Authors.FirstOrDefaultAsync(author => author.Id == id, cancellationToken: cancellationToken);

    public void RemoveAuthor(Author author, CancellationToken cancellationToken)
        => _context.Authors.Remove(author);

    public async Task SaveAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
