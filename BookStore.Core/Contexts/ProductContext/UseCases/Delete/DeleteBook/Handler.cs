using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteBook.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Delete.DeleteBook;

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
            return new Response("Unable to retrieve Book", 500);
        }
        #endregion

        #region Delete Book
        try
        {
            _repository.RemoveBook(book, cancellationToken);
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
        return new Response("Book successfully removed", new ResponseData(request.Id));
        #endregion
    }
}
