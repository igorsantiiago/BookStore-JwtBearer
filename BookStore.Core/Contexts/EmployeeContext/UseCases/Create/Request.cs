using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Create;

public record Request(string FirstName, string LastName, DateTime BirthDate, string Email, string? Password = null) : IRequest<Response>;
