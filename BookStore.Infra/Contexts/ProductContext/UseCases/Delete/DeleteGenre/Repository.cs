using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteGenre.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UseCases.Delete.DeleteGenre;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
        => _context = context;
    public async Task<Genre?> GetGenreAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Genres.FirstOrDefaultAsync(genre => genre.Id == id, cancellationToken: cancellationToken);

    public void RemoveGenre(Genre genre, CancellationToken cancellationToken)
        => _context.Genres.Remove(genre);

    public async Task SaveAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
