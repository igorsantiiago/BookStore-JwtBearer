using BookStore.Core.Contexts.EmployeeContext.Entities;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Delete.Contracts;

public interface IRepository
{
    Task<Employee> GetEmployeeAsync(Guid id, CancellationToken cancellationToken);
    Task RemoveEmployeeAsync(Employee employee, CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}
