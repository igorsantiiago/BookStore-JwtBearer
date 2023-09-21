using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.EmployeeContext.UseCases.Authenticate;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetEmployeeByEmailAsync(string email, CancellationToken cancellationToken)
        => await _context.Employees.AsNoTracking().Include(employee => employee.Roles)
        .FirstOrDefaultAsync(employee => employee.Email.Address == email, cancellationToken);
}
