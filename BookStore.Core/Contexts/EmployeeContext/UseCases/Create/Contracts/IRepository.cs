using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.SharedContext.ValueObjects;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Create.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
    Task SaveAsync(Employee employee, CancellationToken cancellationToken);
}
