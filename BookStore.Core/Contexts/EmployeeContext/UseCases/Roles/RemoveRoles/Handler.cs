using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.RemoveRoles.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.RemoveRoles;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;
    public Handler(IRepository repository)
        => _repository = repository;

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validate Request
        try
        {
            var response = Specification.Validate(request);
            if (!response.IsValid)
                return new Response("Invalid Request", 400, response.Notifications);
        }
        catch
        {
            return new Response("Unable to validate request", 500);
        }
        #endregion

        #region Get Employee and Role
        Employee? employee;
        Role? role;
        try
        {
            employee = await _repository.GetEmployeeByIdAsync(request.IdEmployee, cancellationToken);
            role = await _repository.GetRoleByIdAsync(request.IdRole, cancellationToken);
            if (employee is null || role is null)
                return new Response("Employee or Role Not Found", 404);
        }
        catch
        {
            return new Response("Unable to retrieve employee or role", 500);
        }
        #endregion

        #region Remove Role from Employee
        try
        {
            await _repository.RemoveRoleFromEmployeeAsync(request.IdEmployee, request.IdRole, cancellationToken);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Data Persistence
        try
        {
            await _repository.SaveAsync(cancellationToken);
        }
        catch
        {
            return new Response("Failed on data persistence", 500);
        }
        #endregion

        #region Response
        return new Response("Role sucessfully removed from employee", new ResponseData(request.IdEmployee, request.IdRole));
        #endregion
    }
}
