using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor.Contracts;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateAuthor;

namespace BookStore.Core.Tests.Contexts.ProductContext.UseCases.Create.CreateAuthor;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;
    private readonly Request _invalidFirstNameRequest = new("A", "Baltieri", DateTime.UtcNow);
    private readonly Request _invalidLastNameRequest = new("Andre", "B", DateTime.UtcNow);
    private readonly Request _invalidAuthorAlreadyExists = new("Andre", "Baltieri", DateTime.UtcNow);
    private readonly Request _validRequest = new("Andre", "Baltieri", DateTime.UtcNow);
    private readonly Request _validNewAuthor = new("Martin", "Fowler", DateTime.UtcNow);
    private readonly Request _validDataPersists = new("Eric", "Evans", DateTime.UtcNow);
    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new(_repository);
    }

    #region Should_Fail
    [Fact]
    public void Should_Fail_When_FirstName_Request_Is_Invalid()
    {
        var response = Specification.Validate(_invalidFirstNameRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_LastName_Request_Is_Invalid()
    {
        var response = Specification.Validate(_invalidLastNameRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public async void Should_Fail_When_Author_Already_Exists()
    {
        var response = await _handler.Handle(_invalidAuthorAlreadyExists, new CancellationToken());
        Assert.False(response.IsSuccess);
    }
    #endregion

    #region Should_Succeed
    [Fact]
    public void Should_Succeed_When_Request_Is_Valid()
    {
        var response = Specification.Validate(_validRequest);
        Assert.True(response.IsValid);
    }

    [Fact]
    public async void Should_Succeed_When_New_Author()
    {
        var response = await _handler.Handle(_validNewAuthor, new CancellationToken());
        Assert.True(response.IsSuccess);
    }

    [Fact]
    public async void Should_Succeed_When_Data_Persists()
    {
        var response = await _handler.Handle(_validDataPersists, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
