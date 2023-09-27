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
    }
}