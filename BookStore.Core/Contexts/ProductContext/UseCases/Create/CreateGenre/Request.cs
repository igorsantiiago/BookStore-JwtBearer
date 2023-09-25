using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre;

public record Request(string genreName) : IRequest<Response>;
