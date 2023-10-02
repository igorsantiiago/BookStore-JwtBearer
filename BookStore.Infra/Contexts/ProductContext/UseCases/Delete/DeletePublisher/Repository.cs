using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeletePublisher.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UseCases.Delete.DeletePublisher;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
        => _context = context;
    public async Task<Publisher?> GetPublisherAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Publishers.FirstOrDefaultAsync(publisher => publisher.Id == id, cancellationToken : cancellationToken);

    public void RemovePublisher(Publisher publisher, CancellationToken cancellationToken)
        => _context.Publishers.Remove(publisher);

    public async Task SaveAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
