using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateAuthor.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UseCases.Update.UpdateAuthor;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
        => _context = context;

    public async Task<Author?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Authors.FirstOrDefaultAsync(author => author.Id == id, cancellationToken: cancellationToken);

    public async Task SaveAsync(Author author, CancellationToken cancellationToken)
    {
        _context.Authors.Update(author);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
