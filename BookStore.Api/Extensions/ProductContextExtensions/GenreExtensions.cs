using BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Extensions.ProductContextExtensions;

public static class GenreExtensions
{
    public static void AddGenreContext(this WebApplicationBuilder builder)
    {
        #region Create
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Create.CreateGenre.Repository>();
        #endregion

        #region Update
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateGenre.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Update.UpdateGenre.Repository>();
        #endregion

        #region Delete
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteGenre.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Delete.DeleteGenre.Repository>();
        #endregion
    }

    public static void MapGenreEndpoints(this WebApplication app)
    {
        #region Create
        app.MapPost("api/v1/products/genre", async (
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/products/genre/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Update
        app.MapPut("api/v1/products/genre/update", async (
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateGenre.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateGenre.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateGenre.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.NoContent()
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Delete
        app.MapDelete("api/v1/products/genre/delete", async (
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteGenre.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteGenre.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteGenre.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.NoContent()
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}