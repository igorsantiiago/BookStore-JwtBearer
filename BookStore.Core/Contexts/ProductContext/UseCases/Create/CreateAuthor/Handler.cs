using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Contracts;
using BookStore.Core.Contexts.SharedContext.ValueObjects;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor;

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

        #region Create Object
        Name name;
        Author author;

        try
        {
            name = new(request.FirstName, request.LastName);
            author = new(name, request.BirthDate);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Verify Author
        try
        {
            var exists = await _repository.AnyAsync(request.FirstName, request.LastName, cancellationToken);
            if(exists)
                return new Response("Author already exists", 400);
        }
        catch
        {
            return new Response("Failed to verify registred author", 500);
        }
        #endregion

        #region Data Persistence
        try
        {
            await _repository.SaveAsync(author, cancellationToken);
        }
        catch
        {
            return new Response("Failed to persist data", 500);
        }
        #endregion

        #region Response
        return new Response("Author created successfully", new ResponseData(author.Id, author.Name.FirstName, author.Name.LastName));
        #endregion
    }
}
