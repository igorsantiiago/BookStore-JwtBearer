using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateGenre.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateGenre;

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

        #region Get Genre
        Genre? genre;

        try
        {
            genre = await _repository.GetAuthorByIdAsync(request.Id, cancellationToken);
            if (genre is null)
                return new Response("Genre Not Found", 404);
        }
        catch
        {
            return new Response("Unable to retrieve Genre", 500);
        }
        #endregion

        #region Update Genre
        try
        {
            UpdateGenre(genre, request.Name);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Data Persistence
        try
        {
            await _repository.SaveAsync(genre, cancellationToken);
        }
        catch
        {
            return new Response("Unable to persist data", 500);
        }
        #endregion

        #region Response
        return new Response("Genre successfully updated", new ResponseData(genre.Id, genre.Name));
        #endregion
    }

    private static void UpdateGenre(Genre genre, string genreName)
        => genre.UpdateName(genreName);
}
