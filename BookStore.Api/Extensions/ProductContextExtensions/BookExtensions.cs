using MediatR;

namespace BookStore.Api.Extensions.ProductContextExtensions;

public static class BookExtensions
{
    public static void AddBookContext(this WebApplicationBuilder builder)
    {
        #region Create
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Create.CreateBook.Repository>();
        #endregion
    }

    public static void MapBookEndpoints(this WebApplication app)
    {
        #region Create
        app.MapPost("api/v1/products/book", async (
            BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook.Request request,
            IRequestHandler<
            BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook.Request,
            BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/products/book/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
