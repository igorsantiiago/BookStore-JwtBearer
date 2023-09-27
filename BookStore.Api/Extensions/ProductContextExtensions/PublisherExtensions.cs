using MediatR;

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
    }

    public static void MapPublisherEndpoints(this WebApplication app)
    {
        #region Create
        app.MapPost("api/v1/products/publisher", async(
            BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Request request,
            IRequestHandler<
            BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Request,
            BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/products/publisher/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
