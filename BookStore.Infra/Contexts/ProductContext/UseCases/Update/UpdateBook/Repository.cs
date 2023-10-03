using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateBook.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UseCases.Update.UpdateBook;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
        => _context = context;

    public async Task<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Books.FirstOrDefaultAsync(book => book.Id == id, cancellationToken: cancellationToken);

    public async Task SaveAsync(Book book, CancellationToken cancellationToken)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
