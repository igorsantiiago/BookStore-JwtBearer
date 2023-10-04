using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UseCases.Create.CreateBook;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(string title, Guid IdAuthor, CancellationToken cancellationToken)
        => await _context.Books.AsNoTracking()
            .AnyAsync(book => book.Title == title && book.Authors.Any(author => author.Id == IdAuthor), cancellationToken);

    public async Task<Author?> GetAuthor(Guid id, CancellationToken cancellationToken)
        => await _context.Authors.FirstOrDefaultAsync(author => author.Id == id, cancellationToken);

    public async Task<Genre?> GetGenre(Guid id, CancellationToken cancellationToken)
        => await _context.Genres.FirstOrDefaultAsync(genre => genre.Id == id, cancellationToken);

    public async Task<Publisher?> GetPublisher(Guid id, CancellationToken cancellationToken)
        => await _context.Publishers.FirstOrDefaultAsync(publisher => publisher.Id == id, cancellationToken);

    public async Task SaveAsync(Book book, CancellationToken cancellationToken)
    {
        await _context.Books.AddAsync(book, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
