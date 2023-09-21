using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Request Validation
        try
        {
            var response = Specification.Validate(request);
            if (!response.IsValid)
                return new Response("Invalid Request", 400, response.Notifications);
        }
        catch
        {
            return new Response("Unable to validate your request", 500);
        }
        #endregion

        #region Get Employee
        Employee? employee;
        try
        {
            employee = await _repository.GetEmployeeAsync(request.Email, cancellationToken);
            if (employee is null)
                return new Response("Employee not found!", 404);
        }
        catch
        {
            return new Response("Failed to retrive employee", 500);
        }
        #endregion

        #region Update Password
        try
        {
            employee.ChangePassword(request.Password);
        }
        catch
        {
            return new Response("Failed duraing password change process", 500);
        }
        #endregion

        #region Persist Data
        try
        {
            await _repository.SaveAsync(employee, cancellationToken);
        }
        catch (Exception)
        {
            return new Response("Failed in data persistence", 500);
        }
        #endregion

        return new Response("Successfuly changed password", new ResponseData(employee.Email));
    }
}
