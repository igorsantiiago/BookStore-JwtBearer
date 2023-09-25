using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor;

public record Request(string FirstName, string LastName, DateTime BirthDate) : IRequest<Response>;
