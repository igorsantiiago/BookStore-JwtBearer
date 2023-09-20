using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsEmail(request.Email, "Email", "Invalid Email")
        .IsLowerOrEqualsThan(request.Password.Length, 128, "Password", "Invalid Password")
        .IsGreaterOrEqualsThan(request.Password.Length, 12, "Password", "Invalid Password");
}
