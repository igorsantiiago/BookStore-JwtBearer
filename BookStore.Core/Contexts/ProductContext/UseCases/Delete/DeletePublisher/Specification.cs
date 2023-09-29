using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeletePublisher;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsNullOrEmpty(request.Id.ToString(), "Id", "Invalid Id");
}
