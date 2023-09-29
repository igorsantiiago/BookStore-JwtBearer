using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteGenre.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteGenre;

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

        #region Get Genre
        Genre genre;
        try
        {
            genre = await _repository.GetGenreAsync(request.Id, cancellationToken);
            if (genre is null)
                return new Response("Genre Not Found", 404);
        }
        catch
        {
            return new Response("Unable to retrieve genre", 500);
        }
        #endregion

        #region Delete Genre
        try
        {
            await _repository.RemoveGenreAsync(genre, cancellationToken);
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
        return new Response("Genre successfully deleted", new ResponseData(request.Id));
        #endregion
    }
}
