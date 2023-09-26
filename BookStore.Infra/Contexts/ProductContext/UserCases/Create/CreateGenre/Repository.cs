using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UserCases.Create.CreateGenre;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> AnyAsync(string genreName, CancellationToken cancellationToken)
        => await _context.Genres.AsNoTracking().AnyAsync(genre => genre.GenreName == genreName, cancellationToken: cancellationToken);

    public async Task SaveAsync(Genre genre, CancellationToken cancellationToken)
    {
        await _context.Genres.AddAsync(genre, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
