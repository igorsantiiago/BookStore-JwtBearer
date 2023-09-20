using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData;

public record Request(string FirstName, string LastName, string Email, string? NewEmail = null) : IRequest<Response>;
