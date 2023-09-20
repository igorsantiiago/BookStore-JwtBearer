using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate;

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
        Employee employee;

        try
        {
            employee = await _repository.GetEmployeeByEmailAsync(request.Email, cancellationToken);
            if (employee is null)
                return new Response("Employee not found", 404);
        }
        catch
        {
            return new Response("Failed to retrive employee", 500);
        }
        #endregion

        #region Check Password
            if (!employee.Password.VerifyHash(request.Password))
                return new Response("Username or Password invalid", 400);
        #endregion

        #region Return Data
        try
        {
            var data = new ResponseData
            {
                Id = employee.Id.ToString(),
                FirstName = employee.Name.FirstName,
                LastName = employee.Name.LastName,
                Email = employee.Email,
                Roles = employee.Roles.Select(x => x.Name).ToArray()
            };

            return new Response(string.Empty, data);
        }
        catch
        {

            return new Response("Failed to check employee", 500);
        }
        #endregion
    }
}
