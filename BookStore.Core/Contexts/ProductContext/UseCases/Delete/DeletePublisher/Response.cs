﻿using Flunt.Notifications;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeletePublisher;

public class Response : SharedContext.UseCases.Response
{
    protected Response() { }
    public Response(string message, int status, IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        Status = status;
        Notifications = notifications;
    }
    public Response(string message, ResponseData data)
    {
        Message = message;
        Status = 200;
        Notifications = null;
        Data = data;
    }
    public ResponseData? Data { get; set; }
}

public record ResponseData(Guid Id);
