using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.ValueObjects;
using BookStore.Core.Contexts.SharedContext.ValueObjects;

namespace BookStore.Core.Tests.Contexts.EmployeeContext.UseCases.Update;

public class FakeRepository :
    Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData.Contracts.IRepository,
    Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword.Contracts.IRepository
{
    private readonly Employee _employee;
    public FakeRepository()
    {
        _employee = CreateEmployee("Igor", "Santiago", "test@example.com", DateTime.UtcNow, "FDSH9870Y(*&saioun");
    }

    public Task<Employee?> GetEmployeeAsync(string email, CancellationToken cancellationToken)
    {
        if (email == _employee.Email)
            return Task.FromResult<Employee?>(_employee);

        return Task.FromResult<Employee?>(null);
    }

    public Task SaveAsync(Employee employee, CancellationToken cancellationToken)
    {
        if (employee != null)
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    private static Employee CreateEmployee(string firstName, string lastName, string email, DateTime birthDate, string? password = null)
    {
        Name employeeName = new(firstName, lastName);
        Email employeeEmail = new(email);
        Password employeePassword = new(password);

        var employee = new Employee(employeeName, birthDate, employeeEmail, employeePassword);

        return employee;
    }
}
