using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Delete.Contracts;
using BookStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Contexts.EmployeeContext.UseCases.Delete;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> GetEmployeeAsync(Guid id, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == id, cancellationToken: cancellationToken);
        return employee!;
    }

    public async Task RemoveEmployeeAsync(Employee employee, CancellationToken cancellationToken)
    {
        var user = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
        _context.Employees.Remove(user!);
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
