using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.AddRoles.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.EmployeeContext.UseCases.Roles.AddRoles;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
        => _context = context;

    public async Task<Employee?> GetEmployeeByIdAsync(Guid idEmployee, CancellationToken cancellationToken)
        => await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == idEmployee, cancellationToken);

    public async Task<Role?> GetRoleByIdAsync(Guid idRole, CancellationToken cancellationToken)
        => await _context.Roles.FirstOrDefaultAsync(role => role.Id == idRole, cancellationToken);

    public async Task SaveAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
