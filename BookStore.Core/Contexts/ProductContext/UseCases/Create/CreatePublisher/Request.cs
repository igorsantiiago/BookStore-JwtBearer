using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher;

public record Request(string Name) : IRequest<Response>;
