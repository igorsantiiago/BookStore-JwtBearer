using BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Extensions.ProductContextExtensions;

public static class AuthorExtensions
{
    public static void AddAuthorContext(this WebApplicationBuilder builder)
    {
        #region Create
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Create.CreateAuthor.Repository>();
        #endregion

        #region Update
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateAuthor.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Update.UpdateAuthor.Repository>();
        #endregion

        #region Delete
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteAuhor.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Delete.DeleteAuthor.Repository>();
        #endregion
    }

    public static void MapAuthorEndpoints(this WebApplication app)
    {
        #region Create
        app.MapPost("api/v1/products/author", async(
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/products/author/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Update
        app.MapPut("api/v1/products/author/update", async (
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateAuthor.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateAuthor.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateAuthor.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.NoContent()
                : Results.Json(result, statusCode : result.Status);
        });
        #endregion

        #region Delete
        app.MapDelete("api/v1/products/author/delete", async(
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteAuhor.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteAuhor.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteAuhor.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.NoContent()
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
