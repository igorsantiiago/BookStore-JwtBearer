using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateBook.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateBook;

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

        #region Get Book
        Book? book;
        try
        {
            book = await _repository.GetBookByIdAsync(request.Id, cancellationToken);
            if (book is null)
                return new Response("Book Not Found", 404);
        }
        catch
        {
            return new Response("Unable to retrieve book", 500);
        }
        #endregion

        #region Update Book
        try
        {
            UpdateBook(book, request.Title, request.LaunchDate, request.Description, request.Price);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Data Persistence
        try
        {
            await _repository.SaveAsync(book, cancellationToken);
        }
        catch
        {
            return new Response("Failed in data persistence", 500);
        }
        #endregion

        #region Response
        return new Response("Book successfully updated", new ResponseData(book.Id));
        #endregion
    }

    private static void UpdateBook(Book book, string newTitle, DateTime newDate, string newDescription, decimal newPrice)
    {
        UpdateTitle(book, newTitle);
        UpdateLaunchDate(book, newDate);
        UpdateDescription(book, newDescription);
        UpdatePrice(book, newPrice);
    }

    private static void UpdateTitle(Book book, string newTitle)
        => book.UpdateTitle(newTitle);

    private static void UpdateLaunchDate(Book book, DateTime newDate)
        => book.UpdateLaunchDate(newDate);

    private static void UpdateDescription(Book book, string newDescription)
        => book.UpdateDescription(newDescription);

    private static void UpdatePrice(Book book, decimal newPrice)
        => book.UpdatePrice(newPrice);
}
