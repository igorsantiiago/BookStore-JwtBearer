using BookStore.Core.Contexts.EmployeeContext.Entities;

namespace BookStore.Core.Tests.Utils.EmployeeContext;

public class RoleUtils
{
    public static Role CreateRole(string name)
    {
        Role role = new()
        {
            Name = name
        };

        return role;
    }
}
