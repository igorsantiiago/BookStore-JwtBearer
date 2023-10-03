using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdatePublisher.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.ProductContext.UseCases.Update.UpdatePublisher;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
        => _context = context;

    public async Task<Publisher?> GetPublisherByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Publishers.FirstOrDefaultAsync(publisher => publisher.Id == id, cancellationToken: cancellationToken);

    public async Task SaveAsync(Publisher publisher, CancellationToken cancellationToken)
    {
        _context.Publishers.Update(publisher);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
