using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData;

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
            return new Response("Unable to validate request", 500);
        }

        #endregion

        #region Get Employee

        Employee? employee;

        try
        {
            employee = await _repository.GetEmployeeAsync(request.Email, cancellationToken);
            if (employee == null)
                return new Response("Employee not found", 400);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 500);
        }

        #endregion

        #region Update Employee
        try
        {
            UpdateEmployeeName(employee, request.FirstName, request.LastName);
            if (request.NewEmail != null)
                UpdateEmployeeEmail(employee, request.NewEmail);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }

        #endregion

        #region Data Persistence
        try
        {
            await _repository.SaveAsync(employee, cancellationToken);
        }
        catch
        {
            return new Response("Failed  in data persistence", 500);
        }
        #endregion

        #region Response
        return new Response("Employee created successfully", 
            new ResponseData(employee.Id, employee.Name.FirstName, employee.Email));
        #endregion
    }

    private static void UpdateEmployeeName(Employee employee, string firstName, string lastName)
        => employee.UpdateName(firstName, lastName);

    private static void UpdateEmployeeEmail(Employee employee, string email)
        => employee.UpdateEmail(email);
}
