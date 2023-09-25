using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher;

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

        #region Create Publisher
        Publisher publisher;

        try
        {
            publisher = new(request.Name);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Verify Publisher Existence
        try
        {
            var exists = await _repository.AnyAsync(request.Name);
            if (exists)
                return new Response("Publisher already exists", 400);
        }
        catch
        {
            return new Response("Failed to verify registred publisher", 500);
        }
        #endregion

        #region Persist Data
        try
        {
            await _repository.SaveAsync(publisher, cancellationToken);
        }
        catch
        {
            return new Response("Failed to persist data", 500);
        }
        #endregion

        #region Response
        return new Response("Publisher created successfully", new ResponseData(publisher.Id, publisher.Name));
        #endregion
    }
}
