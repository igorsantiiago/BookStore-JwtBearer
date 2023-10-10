using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Delete.Contracts;
using BookStore.Core.Contexts.EmployeeContext.ValueObjects;
using BookStore.Core.Contexts.SharedContext.ValueObjects;
using BookStore.Core.Tests.Utils.EmployeeContext;

namespace BookStore.Core.Tests.Contexts.EmployeeContext.UseCases.Delete;

public class FakeRepository : IRepository
{
    private readonly Employee _employee;
    public FakeRepository()
    {
        _employee = EmployeeUtils.CreateEmployee("Igor", "Santiago", "test@example.com", DateTime.UtcNow, "FDSH9870Y(*&saioun");
    }
    public Task<Employee?> GetEmployeeAsync(Guid id, CancellationToken cancellationToken)
    {
        Guid customGuid = new("4c6a9c4a-ff72-499e-9e69-c6bfa0d23b2e");
        if (id == customGuid)
            return Task.FromResult<Employee?>(_employee);

        return Task.FromResult<Employee?>(null);
    }

    public void RemoveEmployee(Employee employee, CancellationToken cancellationToken)
    {
        return;
    }

    public Task SaveAsync(CancellationToken cancellationToken)
        => Task.FromResult(true);
}