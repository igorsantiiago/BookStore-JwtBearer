using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateGenre.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UseCases.Update.UpdateGenre;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
        => _context = context;

    public async Task<Genre?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Genres.FirstOrDefaultAsync(genre => genre.Id == id, cancellationToken: cancellationToken);

    public async Task SaveAsync(Genre genre, CancellationToken cancellationToken)
    {
        _context.Genres.Update(genre);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
