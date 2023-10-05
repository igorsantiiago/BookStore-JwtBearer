using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.RemoveRoles;

public record Request(Guid IdEmployee, Guid IdRole) : IRequest<Response>;
