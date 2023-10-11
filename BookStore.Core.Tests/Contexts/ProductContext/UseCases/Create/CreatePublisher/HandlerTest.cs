using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher;
using BookStore.Core.Contexts.ProductContext.UseCases.Create.CreatePublisher.Contracts;

namespace BookStore.Core.Tests.Contexts.ProductContext.UseCases.Create.CreatePublisher;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;
    private readonly Request _invalidRequest = new("Ar");
    private readonly Request _invalidAlreadyExists = new("DarkSide");
    private readonly Request _validRequest = new("Arqueiro");


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
    public async void Should_Fail_When_Publisher_Already_Exists()
    {
        var response = await _handler.Handle(_invalidAlreadyExists, new CancellationToken());
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
    public async void Should_Succeed_When_New_Publisher()
    {
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }

    [Fact]
    public async void Should_Succeed_When_Data_Persists()
    {
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
