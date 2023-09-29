using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteAuhor;

public record Request(Guid Id) : IRequest<Response>;
