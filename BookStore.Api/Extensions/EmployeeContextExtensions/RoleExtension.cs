using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Extensions.EmployeeContextExtensions;

public static class RoleExtension
{
    public static void AddRoleContext(this WebApplicationBuilder builder)
    {
        #region AddEmployeeRole
        builder.Services.AddTransient<
            BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.AddRoles.Contracts.IRepository,
            BookStore.Infra.Contexts.EmployeeContext.UseCases.Roles.AddRoles.Repository>();
        #endregion

        #region RemoveEmployeeRole
        builder.Services.AddTransient<
            BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.RemoveRoles.Contracts.IRepository,
            BookStore.Infra.Contexts.EmployeeContext.UseCases.Roles.RemoveRoles.Repository>();
        #endregion
    }

    public static void MapRoleEndpoints(this WebApplication app)
    {
        #region AddEmployeeRole
        app.MapPut("api/v1/employee/role/add", async (
            [FromBody] BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.AddRoles.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.AddRoles.Request,
                BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.AddRoles.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.NoContent()
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region RemoveEployeeRole
        app.MapPut("api/v1/employee/role/remove", async (
            [FromBody] BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.RemoveRoles.Request request,
            [FromServices] IRequestHandler<
                BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.RemoveRoles.Request,
                BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.RemoveRoles.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.NoContent()
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
