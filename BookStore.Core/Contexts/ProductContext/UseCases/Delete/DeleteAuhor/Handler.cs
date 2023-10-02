using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteAuhor.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteAuhor;

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

        #region Get Author
        Author? author;
        try
        {
            author = await _repository.GetAuthorAsync(request.Id, cancellationToken);
            if (author is null)
                return new Response("Author not found", 404);
        }
        catch
        {
            return new Response("Unable to retrieve author", 500);
        }
        #endregion

        #region Delete Author
        try
        {
            _repository.RemoveAuthor(author, cancellationToken);
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

        #region Response
        return new Response("Author removed successfully", new ResponseData(request.Id));
        #endregion
    }
}
