using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate.Contracts;
using BookStore.Core.Tests.Utils.EmployeeContext;

namespace BookStore.Core.Tests.Contexts.EmployeeContext.UseCases.Authenticate;

public class FakeRepository : IRepository
{
    private readonly Employee _validEmployee = EmployeeUtils.CreateEmployee("Igor", "Santiago", "test@example.com", DateTime.Now, "HD90NSUdojin(COJD0()Ivmaiksyg");
    public Task<Employee?> GetEmployeeByEmailAsync(string email, CancellationToken cancellationToken)
    {
        if (email == _validEmployee.Email)
            return Task.FromResult<Employee?>(_validEmployee);

        return Task.FromResult<Employee?>(null);
    }
}
