using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteGenre;

public record Request(Guid Id) : IRequest<Response>;
