using BookStore.Core.Contexts.ProductContext.Entities;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateBook;

public record Request(Guid Id, string Title, DateTime LaunchDate, string Description, decimal Price) : IRequest<Response>;
