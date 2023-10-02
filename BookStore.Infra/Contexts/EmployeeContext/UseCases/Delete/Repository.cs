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

    public async Task<Employee?> GetEmployeeAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == id, cancellationToken: cancellationToken);

    public void RemoveEmployee(Employee employee, CancellationToken cancellationToken)
        => _context.Employees.Remove(employee);

    public async Task SaveAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
