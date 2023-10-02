using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdatePublisher;

public record Request(Guid Id, string Name) : IRequest<Response>;
