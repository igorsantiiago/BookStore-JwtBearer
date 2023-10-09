using BookStore.Core.Contexts.EmployeeContext.UseCases.Create;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Create.Contracts;

namespace BookStore.Core.Tests.Contexts.EmployeeContext.UseCases.Create;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;
    private readonly Request _invalidEmailAlreadyExists = new("Igor", "Santiago", DateTime.UtcNow, "teste@example.com", "ASHsju9m)(&dhn87SN8");
    private readonly Request _invalidFirstName = new("I", "Santiago", DateTime.UtcNow, "test@example.com", "ASHsju9m)(&dhn87SN8");
    private readonly Request _invalidLastName = new("Igor", "S", DateTime.UtcNow, "test@example.com", "ASHsju9m)(&dhn87SN8");
    private readonly Request _invalidPassword = new("Igor", "Santiago", DateTime.UtcNow, "test@example.com", "ASHs");
    private readonly Request _validRequest = new("Igor", "Santiago", DateTime.UtcNow, "test@example.com", "ASHsju9m)(&dhn87SN8");

    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new Handler(_repository);
    }

    #region Should_Fail
    [Fact]
    public async void Should_Fail_When_Email_Already_Exists()
    {
        var response = await _handler.Handle(_invalidEmailAlreadyExists, new CancellationToken());
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Fail_When_FirstName_Is_Invalid()
    {
        var response = await _handler.Handle(_invalidFirstName, new CancellationToken());
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Fail_When_LastName_Is_Invalid()
    {
        var response = await _handler.Handle(_invalidLastName, new CancellationToken());
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Fail_When_Password_Is_Invalid()
    {
        var response = await _handler.Handle(_invalidPassword, new CancellationToken());
        Assert.False(response.IsSuccess);
    }
    #endregion

    #region Should_Succeed
    [Fact]
    public async void Should_Succeed_When_Request_Is_Valid()
    {
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion

}
