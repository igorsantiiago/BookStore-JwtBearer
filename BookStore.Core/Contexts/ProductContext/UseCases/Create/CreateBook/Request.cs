using BookStore.Core.Contexts.ProductContext.Entities;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook;

public record Request(string Title, DateTime LaunchDate, string Description, decimal Price, Author Author, Publisher Publisher, Genre Genre) : IRequest<Response>;
