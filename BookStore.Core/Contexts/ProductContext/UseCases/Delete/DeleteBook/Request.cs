using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteBook;

public record Request(Guid Id) : IRequest<Response>;
