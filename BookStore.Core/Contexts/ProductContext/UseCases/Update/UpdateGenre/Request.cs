using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateGenre;

public record Request(Guid Id, string Name) : IRequest<Response>;
