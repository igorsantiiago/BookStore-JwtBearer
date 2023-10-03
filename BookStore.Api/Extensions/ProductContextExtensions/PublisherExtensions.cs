using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Extensions.ProductContextExtensions;

public static class PublisherExtensions
{
    public static void AddPublisherContext(this WebApplicationBuilder builder)
    {
        #region Create
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Create.CreatePublisher.Repository>();
        #endregion

        #region Update
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdatePublisher.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Update.UpdatePublisher.Repository>();
        #endregion

        #region Delete
        builder.Services.AddTransient<
            BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeletePublisher.Contracts.IRepository,
            BookStore.Infra.Contexts.ProductContext.UseCases.Delete.DeletePublisher.Repository>();
        #endregion
    }

    public static void MapPublisherEndpoints(this WebApplication app)
    {
        #region Create
        app.MapPost("api/v1/products/publisher", async(
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/products/publisher/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Update
        app.MapPut("api/v1/products/publisher/update", async (
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdatePublisher.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdatePublisher.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdatePublisher.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.NoContent()
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Delete
        app.MapDelete("api/v1/products/publisher/delete", async (
            [FromBody] BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeletePublisher.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeletePublisher.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeletePublisher.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.NoContent()
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
