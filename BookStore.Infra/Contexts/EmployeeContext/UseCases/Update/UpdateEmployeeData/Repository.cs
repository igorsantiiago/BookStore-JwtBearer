using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetEmployeeAsync(string email, CancellationToken cancellationToken)
        => await _context.Employees.FirstOrDefaultAsync(employee => employee.Email.Address == email, cancellationToken: cancellationToken);

    public async Task SaveAsync(Employee employee, CancellationToken cancellationToken)
    {
        await _context.Employees.AddAsync(employee, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
