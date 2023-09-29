using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeletePublisher.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeletePublisher;

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
            var result = Specification.Validate(request);
            if (!result.IsValid)
                return new Response("Invalid Request", 400, result.Notifications);
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
            publisher = await _repository.GetPublisherAsync(request.Id, cancellationToken);
            if (publisher is null)
                return new Response("Publisher Not Found", 404);
        }
        catch
        {
            return new Response("Unable to retrieve publisher", 500);
        }
        #endregion

        #region Remove Publisher
        try
        {
            await _repository.RemovePublisherAsync(publisher, cancellationToken);
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
            return new Response("Failed to persist data", 500);
        }
        #endregion

        #region Response
        return new Response("Publisher successfully removed", new ResponseData(request.Id));
        #endregion
    }
}
