using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Tests.Utils.EmployeeContext;

namespace BookStore.Core.Tests.Contexts.EmployeeContext.UseCases.Update;

public class FakeRepository :
    Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData.Contracts.IRepository,
    Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword.Contracts.IRepository
{
    private readonly Employee _employee;
    public FakeRepository()
    {
        _employee = EmployeeUtils.CreateEmployee("Igor", "Santiago", "test@example.com", DateTime.UtcNow, "FDSH9870Y(*&saioun");
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
}
