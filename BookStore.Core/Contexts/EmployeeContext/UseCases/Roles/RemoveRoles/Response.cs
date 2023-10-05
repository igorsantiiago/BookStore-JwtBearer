using Flunt.Notifications;

namespace BookStore.Core.Contexts.EmployeeContext.UseCases.Roles.RemoveRoles;

public class Response : SharedContext.UseCases.Response
{
    public Response() { }
    public Response(string message, int status, IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        Status = status;
        Notifications = notifications;
    }
    public Response(string message, ResponseData data)
    {
        Message = message;
        Status = 204;
        Notifications = null;
        Data = data;
    }
    public ResponseData? Data { get; set; }
}

public record ResponseData(Guid IdEmployee, Guid IdRole);
