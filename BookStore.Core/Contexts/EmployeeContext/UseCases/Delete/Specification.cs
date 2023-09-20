using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Delete;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsNotNull(request.Id, "Id", "Invalid Id")
        .IsEmail(request.Email, "Email", "Invalid Email");
}
