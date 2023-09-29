using BookStore.Core.Contexts.ProductContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteBook.Contracts;

public interface IRepository
{
    Task<Book> GetBookAsync(Guid id, CancellationToken cancellationToken);
    Task RemoveBookAsync(Book book, CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}
