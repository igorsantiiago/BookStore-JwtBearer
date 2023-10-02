using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateGenre;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsNullOrEmpty(request.Id.ToString(), "Id", "Invalid ID")
        .IsLowerOrEqualsThan(request.Name.Length, 40, "Name", "The genre name need to have maximum 40 characters")
        .IsGreaterOrEqualsThan(request.Name.Length, 3, "Name", "The genre name need to have minumum 3 characters");
}
