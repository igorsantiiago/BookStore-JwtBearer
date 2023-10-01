using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateAuthor;

public record Request(Guid Id, string FirstName, string LastName, DateTime BirthDate) : IRequest<Response>;
