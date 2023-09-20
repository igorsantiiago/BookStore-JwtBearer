using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword;

public record Request(string Email, string Password) : IRequest<Response>;