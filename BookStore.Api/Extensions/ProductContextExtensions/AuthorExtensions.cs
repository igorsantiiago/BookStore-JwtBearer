using MediatR;

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
    }

    public static void MapAuthorEndpoints(this WebApplication app)
    {
        #region Create
        app.MapPost("api/v1/products/author", async(
            BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Request request,
            IRequestHandler<
                BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Request,
                BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/products/author/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
