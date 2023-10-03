using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        #region Update
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateBook.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Update.UpdateBook.Repository>();
        #endregion

        #region Delete
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteBook.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Delete.DeleteBook.Repository>();
        #endregion
    }

    public static void MapBookEndpoints(this WebApplication app)
    {
        #region Create
        app.MapPost("api/v1/products/book", async (
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/products/book/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Update
        app.MapPut("api/v1/products/book/update", async (
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateBook.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateBook.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateBook.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.NoContent()
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Delete
        app.MapDelete("api/v1/products/book/delete", async (
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteBook.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteBook.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteBook.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.NoContent()
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
