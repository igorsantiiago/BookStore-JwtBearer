using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UserCases.Create.CreatePublisher;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(string name, CancellationToken cancellationToken)
        => await _context.Publishers.AsNoTracking().AnyAsync(publisher => publisher.Name == name, cancellationToken: cancellationToken);

    public async Task SaveAsync(Publisher publisher, CancellationToken cancellationToken)
    {
        await _context.Publishers.AddAsync(publisher, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
