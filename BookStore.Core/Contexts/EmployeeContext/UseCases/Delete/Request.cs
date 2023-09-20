using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Delete;

public record Request(Guid Id, string Email) : IRequest<Response>;
