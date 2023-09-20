using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsEmail(request.Email, "Email", "Invalid Email")
        .IsLowerOrEqualsThan(request.Password.Length, 128, "Password", "The maximum legnth of password is 128 characters.")
        .IsGreaterOrEqualsThan(request.Password.Length, 12, "Password", "The minimum length of password is 12 characters.");
}
