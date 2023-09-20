using BookStore.Core.Contexts.EmployeeContext.Entities;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate.Contracts;

public interface IRepository
{
    Task<Employee> GetEmployeeByEmailAsync(string email, CancellationToken cancellationToken);
}
