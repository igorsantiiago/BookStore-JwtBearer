using BookStore.Core.Contexts.EmployeeContext.Entities;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.AddRoles.Contracts;

public interface IRepository
{
    Task<Employee?> GetEmployeeByIdAsync(Guid idEmployee, CancellationToken cancellationToken);
    Task<Role?> GetRoleByIdAsync(Guid idRole, CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}
