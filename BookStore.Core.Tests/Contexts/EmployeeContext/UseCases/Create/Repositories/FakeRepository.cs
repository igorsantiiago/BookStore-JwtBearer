using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Create.Contracts;

namespace BookStore.Core.Tests.Contexts.EmployeeContext.UseCases.Create.Repositories;

public class FakeRepository : IRepository
{
    public Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
    {
        if (email == "teste@example.com")
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    public Task SaveAsync(Employee employee, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}
