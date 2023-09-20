using BookStore.Core.Contexts.EmployeeContext.Entities;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword.Contracts;

public interface IRepository
{
    Task<Employee> GetEmployeeAsync(string email, CancellationToken cancellationToken);
    Task SaveAsync(Employee employee, CancellationToken cancellationToken);
}
