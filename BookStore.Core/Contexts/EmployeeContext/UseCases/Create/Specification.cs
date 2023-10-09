using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Create;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsLowerOrEqualsThan(request.FirstName.Length, 50, "FirstName", "The maximum length of first name is 50 characters.")
        .IsGreaterOrEqualsThan(request.FirstName.Length, 3, "FirstName", "The minimum length of first name is 3 characters.")
        .IsLowerOrEqualsThan(request.LastName.Length, 50, "LastName", "The maximum length of last name is 50 characters.")
        .IsGreaterOrEqualsThan(request.LastName.Length, 3, "LastName", "The minimum length of last name is 3 characters.")
        .IsNotNullOrEmpty(request.BirthDate.ToString(), "BirthDate", "Birth date field is required.")
        .IsEmail(request.Email, "Email", "Invalid Email")
        .IsLowerOrEqualsThan(request.Password!.Length, 128, "Password", "The maximum legnth of password is 128 characters.")
        .IsGreaterOrEqualsThan(request.Password!.Length, 12, "Password", "The minimum length of password is 12 characters.");
}
