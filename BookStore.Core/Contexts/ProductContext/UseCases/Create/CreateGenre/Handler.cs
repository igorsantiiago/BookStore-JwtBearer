using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre;

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

        #region Create Genre
        Genre genre;

        try
        {
            genre = new(request.genreName);
        }
        catch(Exception ex)
        {
            return new Response(ex.Message, 500);
        }
        #endregion

        #region Verify Existence
        try
        {
            var exists = await _repository.AnyAsync(request.genreName, cancellationToken);
            if (exists)
                return new Response("Genre already exists", 400);
        }
        catch
        {
            return new Response("Failed to verify registered genre", 500);
        }
        #endregion

        #region Persist Data
        try
        {
            await _repository.SaveAsync(genre, cancellationToken);
        }
        catch
        {
            return new Response("Failed to persist data", 500);
        }
        #endregion

        #region Response
        return new Response("Genre created successfully", new ResponseData(genre.Id, genre.GenreName));
        #endregion
    }
}
