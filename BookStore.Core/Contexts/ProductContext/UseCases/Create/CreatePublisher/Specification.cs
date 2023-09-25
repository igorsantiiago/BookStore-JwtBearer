using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsLowerOrEqualsThan(request.Name, 80, "Name", "The maximum length for publisher name is 80 characters")
        .IsGreaterOrEqualsThan(request.Name, 3, "Name", "The minimum length for publisher name is 3 characters");
}
