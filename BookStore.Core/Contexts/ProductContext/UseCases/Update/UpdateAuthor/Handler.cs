using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateAuthor.Contracts;
using MediatR;

namespace BookStore.Core.Contexts.ProductContext.UseCases.Update.UpdateAuthor;

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
        Author author;
        try
        {
            author = await _repository.GetAuthorByIdAsync(request.Id, cancellationToken);
            if (author is null)
                return new Response("Auhot Not Found", 404);
        }
        catch
        {
            return new Response("Unable to retrieve author", 500);
        }
        #endregion

        #region Update Author
        try
        {
            UpdateAuthorName(author, request.FirstName, request.LastName);
            UpdateAuthorBirthDate(author, request.BirthDate);
        }
        catch(Exception ex)
        {
            return new Response(ex.Message, 400);
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
        return new Response("Author successfully updated", new ResponseData(author.Id, author.Name.FirstName));
        #endregion
    }

    public void UpdateAuthorName(Author author, string firstName, string lastName)
        => author.ChangeName(firstName, lastName);

    public void UpdateAuthorBirthDate(Author author, DateTime birthDate) 
        => author.ChangeBirthDate(birthDate);
}
