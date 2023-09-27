using BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate;
using MediatR;

namespace BookStore.Api.Extensions.EmployeeContextExtensions;

public static class EmployeeContextExtension
{
    public static void AddEmployeeContext(this WebApplicationBuilder builder)
    {
        #region Authenticate
        builder.Services.AddTransient<
            Core.Contexts.EmployeeContext.UseCases.Authenticate.Contracts.IRepository,
            Infra.Contexts.EmployeeContext.UseCases.Authenticate.Repository
            >();
        #endregion

        #region Create
        builder.Services.AddTransient<
            Core.Contexts.EmployeeContext.UseCases.Create.Contracts.IRepository,
            Infra.Contexts.EmployeeContext.UseCases.Create.Repository
            >();
        #endregion

        #region UpdateEmployeeData
        builder.Services.AddTransient<
            Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData.Contracts.IRepository,
            Infra.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData.Repository
            >();
        #endregion

        #region UpdateEmployeePassword
        builder.Services.AddTransient<
            Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword.Contracts.IRepository,
            Infra.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword.Repository
            >();
        #endregion

        #region Delete
        builder.Services.AddTransient<
            Core.Contexts.EmployeeContext.UseCases.Delete.Contracts.IRepository,
            Infra.Contexts.EmployeeContext.UseCases.Delete.Repository
            >();
        #endregion

    }

    public static void MapEmployeeEndpoints(this WebApplication app)
    {
        #region Authenticate
        app.MapPost("api/v1/authenticate", async (
            Request request,
            IRequestHandler<
                Request,
                Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());

            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.Data is null)
                return Results.Json(result, statusCode: 500);

            result.Data.Token = JwtExtension.Generate(result.Data);
            return Results.Ok(result);
        });
        #endregion

        #region Create
        app.MapPost("api/v1/employee/create", async (
            Core.Contexts.EmployeeContext.UseCases.Create.Request request,
            IRequestHandler<
                Core.Contexts.EmployeeContext.UseCases.Create.Request,
                Core.Contexts.EmployeeContext.UseCases.Create.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/employee/create/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region UpdateEmployeeData
        app.MapPut("api/v1/employee/update/data", async (
            Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData.Request request,
            IRequestHandler<
                Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData.Request,
                Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region UpdateEmployeePassword
        app.MapPut("api/v1/employee/update/password", async (
            Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword.Request request,
            IRequestHandler<
                Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword.Request,
                Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Delete
        app.MapDelete("api/v1/employee/delete", async (
            Core.Contexts.EmployeeContext.UseCases.Delete.Request request,
            IRequestHandler<
                Core.Contexts.EmployeeContext.UseCases.Delete.Request,
                Core.Contexts.EmployeeContext.UseCases.Delete.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
