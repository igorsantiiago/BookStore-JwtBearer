using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteAuhor;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsNotNullOrEmpty(request.Id.ToString(), "Id", "Invalid Id");
}
