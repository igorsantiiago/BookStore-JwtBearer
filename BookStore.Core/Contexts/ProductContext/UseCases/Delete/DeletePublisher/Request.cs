using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeletePublisher;

public record Request(Guid Id) : IRequest<Response>;
