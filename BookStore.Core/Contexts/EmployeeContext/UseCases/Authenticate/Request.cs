using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate;

public record Request(string Email, string Password) : IRequest<Response>;
