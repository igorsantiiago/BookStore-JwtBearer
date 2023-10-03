using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateBook;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsNullOrEmpty(request.Id.ToString(), "Id", "Invalid ID")
        .IsLowerOrEqualsThan(request.Title.Length, 80, "Title", "The title of the book needs to be maximum 80 characters")
        .IsGreaterOrEqualsThan(request.Title.Length, 3, "Title", "The title of the book needs to be minimum 3 characters")
        .IsLowerOrEqualsThan(request.Description.Length, 500, "Description", "The description of the book needs to be maximum 500 characters")
        .IsGreaterOrEqualsThan(request.Description.Length, 3, "Description", "The description of the book needs to be minimum 3 characters")
        .IsGreaterOrEqualsThan(request.Price, 0, "Price", "The price of the book needs to be higher or equals 0")
        .IsNullOrEmpty(request.Author.Name.FirstName, "Author", "Author required")
        .IsNullOrEmpty(request.Publisher.Name, "Publisher", "Publisher required")
        .IsNullOrEmpty(request.Genre.Name, "Genre", "Genre required");
}
