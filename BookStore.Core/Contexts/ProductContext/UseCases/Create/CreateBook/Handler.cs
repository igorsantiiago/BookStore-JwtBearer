using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateBook;

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
        Book book;

        try
        {
            book = new(request.Title, request.LaunchDate, request.Description, request.Price);
        }
        catch(Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Verify Existence
        try
        {
            var exists = await _repository.AnyAsync(request.Title, request.Author, cancellationToken);
            if (exists)
                return new Response("Book already exists", 400);
        }
        catch
        {
            return new Response("Failed to verify registered books", 500);
        }
        #endregion

        #region Add Author, Publisher and Genre
        Author author;
        Publisher publisher;
        Genre genre;

        try
        {
            author = await _repository.GetAuthor(request.Author.Id);
            if (author == null)
                return new Response("Author not found", 404);

            publisher = await _repository.GetPublisher(request.Publisher.Id);
            if (publisher == null)
                return new Response("Publisher not found", 404);

            genre = await _repository.GetGenre(request.Genre.Id);
            if (genre == null)
                return new Response("Genre not found", 404);

            book.AddAuthor(author);
            book.AddPublisher(publisher);
            book.AddGenre(genre);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Persist Data
        try
        {
            await _repository.SaveAsync(book, cancellationToken);
        }
        catch
        {
            return new Response("Failed to persist data", 500);
        }
        #endregion

        #region Response
        return new Response("Book created successfully", new ResponseData(book.Id, book.Title));
        #endregion
    }
}
