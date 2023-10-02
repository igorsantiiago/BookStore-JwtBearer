using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteBook.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UseCases.Delete.DeleteBook;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
        => _context = context;
    public async Task<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Books.FirstOrDefaultAsync(book => book.Id ==  id, cancellationToken: cancellationToken);

    public void RemoveBook(Book book, CancellationToken cancellationToken)
        => _context.Books.Remove(book);

    public async Task SaveAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
