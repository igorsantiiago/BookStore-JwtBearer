using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdatePublisher.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdatePublisher;

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

        #region Get Publisher
        Publisher publisher;

        try
        {
            publisher = await _repository.GetPublisherByIdAsync(request.Id, cancellationToken);
            if (publisher is null)
                return new Response("Publisher Not Found", 404);
        }
        catch
        {
            return new Response("Unable to retrieve publisher", 500);
        }
        #endregion

        #region Update Publisher
        try
        {
            UpdatePublisher(publisher, request.Name);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Data Persistence
        try
        {
            await _repository.SaveAsync(publisher, cancellationToken);
        }
        catch
        {
            return new Response("Failed in data persistence", 500);
        }
        #endregion

        #region Response
        return new Response("Publisher successfully updated", new ResponseData(publisher.Id, publisher.Name));
        #endregion
    }

    private static void UpdatePublisher(Publisher publisher, string name)
        => publisher.UpdateName(name);
}
