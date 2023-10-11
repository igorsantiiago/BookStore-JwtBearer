using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreateGenre.Contracts;

namespace BookStore.Core.Tests.Contexts.ProductContext.UseCases.Create.CreateGenre;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;
    private readonly Request _invalidRequest = new("Dr");
    private readonly Request _invalidAlreadyExists = new("Ficção Cientifica");
    private readonly Request _validRequest = new("Drama");
    private readonly Request _validNewGenre = new("Comedy");


    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new(_repository);
    }

    #region Should_Fail
    [Fact]
    public void Should_Fail_When_Request_Is_Invalid()
    {
        var response = Specification.Validate(_invalidRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public async void Should_Fail_When_Genre_Already_Exists()
    {
        var response = await _handler.Handle(_invalidAlreadyExists, new CancellationToken());
        Assert.False(response.IsSuccess);
    }
    #endregion

    #region Should_Succeed
    [Fact]
    public async void Should_Succeed_When_Request_is_Valid()
    {
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }

    [Fact]
    public async void Should_Succeed_When_New_Genre()
    {
        var response = await _handler.Handle(_validNewGenre, new CancellationToken());
        Assert.True(response.IsSuccess);
    }

    [Fact]
    public async void Should_Succeed_When_Persist_Data()
    {
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
