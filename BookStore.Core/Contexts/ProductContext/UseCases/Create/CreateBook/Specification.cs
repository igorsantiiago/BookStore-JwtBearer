using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsLowerOrEqualsThan(request.Title.Length, 80, "Title", "The title of the book needs to be maximum 80 characters")
        .IsGreaterOrEqualsThan(request.Title.Length, 3, "Title", "The title of the book needs to be minimum 3 characters")
        .IsLowerOrEqualsThan(request.Description.Length, 500, "Description", "The description of the book needs to be maximum 500 characters")
        .IsGreaterOrEqualsThan(request.Description.Length, 3, "Description", "The description of the book needs to be minimum 3 characters")
        .IsGreaterOrEqualsThan(request.Price, 0, "Price", "The price of the book needs to be higher or equals 0");
}
