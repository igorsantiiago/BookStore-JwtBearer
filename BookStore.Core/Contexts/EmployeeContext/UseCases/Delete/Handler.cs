using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Delete.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Delete;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

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

        #region Get Employee
        Employee employee;

        try
        {
            employee = await _repository.GetEmployeeAsync(request.Id, cancellationToken);
            if (employee is null)
                return new Response("Employee not found", 404);
        }
        catch
        {
            return new Response("Unable to retrieve employee", 500);
        }
        #endregion

        #region Delete Employee
        try
        {
            await _repository.RemoveEmployeeAsync(employee, cancellationToken);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Persist Data
        try
        {
            await _repository.SaveAsync(cancellationToken);
        }
        catch
        {
            return new Response("Failed in data persistence", 500);
        }
        #endregion

        return new Response("Employee removed successfuly", new ResponseData(request.Id, request.Email));
    }
}
