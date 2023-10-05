using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.AddRoles;

public record Request(Guid IdEmployee, Guid IdRole) : IRequest<Response>;
