using BookStore.Core.Contexts.SharedContext.Entities;

namespace BookStore.Core.Contexts.EmployeeContext.Entities;

public class Role : Entity
{
    public string Name { get; set; } = string.Empty;
    public List<Employee> Employees { get; set; } = new();
}
