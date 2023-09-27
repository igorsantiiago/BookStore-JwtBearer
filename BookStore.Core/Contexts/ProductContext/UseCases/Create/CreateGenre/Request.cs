using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre;

public record Request(string Name) : IRequest<Response>;
