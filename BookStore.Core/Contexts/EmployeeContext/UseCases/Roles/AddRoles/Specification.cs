using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.AddRoles;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires();
}
