using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateBook.Contracts;

public interface IRepository
{
    Task<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken);
    Task SaveAsync(Book book, CancellationToken cancellationToken);
}
