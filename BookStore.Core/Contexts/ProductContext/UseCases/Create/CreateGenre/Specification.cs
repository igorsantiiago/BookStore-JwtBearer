using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsLowerOrEqualsThan(request.genreName.Length, 40, "GenreName", "The genre name need to have maximum 40 characters")
        .IsGreaterOrEqualsThan(request.genreName.Length, 3, "GenreName", "The genre name need to have minumum 3 characters");
}
