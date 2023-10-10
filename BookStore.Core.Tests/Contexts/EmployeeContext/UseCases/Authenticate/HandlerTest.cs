using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Authenticate.Contracts;
using BookStore.Core.Tests.Utils;

namespace BookStore.Core.Tests.Contexts.EmployeeContext.UseCases.Authenticate;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;
    private readonly Request _validRequest = new("test@example.com", "HD90NSUdojin(COJD0()Ivmaiksyg");
    private readonly Request _invalidPasswordRequest = new("test@example.com", "HD9");
    private readonly Request _invalidEmailRequest = new("testexample.com", "HD90NSUdojin(COJD0()Ivmaiksyg");
    private readonly Request _invalidEmployeeResponse = new("testando@example.com", "HD90NSUdojin(COJD0()Ivmaiksyg");
    private readonly Request _invalidPasswordResponse = new("test@example.com", "HD90NSUdojin(COJD0()Ivm");

    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new(_repository);
    }

    #region Should_Fail
    [Fact]
    public void Should_Fail_When_Password_Request_Is_Invalid()
    {
        var response = Specification.Validate(_invalidPasswordRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public void Should_Fail_When_Email_Request_Is_Invalid()
    {
        var response = Specification.Validate(_invalidEmailRequest);
        Assert.False(response.IsValid);
    }

    [Fact]
    public async void Should_Fail_When_Employee_Is_Invalid()
    {
        var response = await _handler.Handle(_invalidEmployeeResponse, new CancellationToken());
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Fail_When_Password_Is_Invalid()
    {
        var response = await _handler.Handle(_invalidPasswordResponse, new CancellationToken());
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
    public async void Should_Succeed_When_Employee_And_Password_Are_Valid()
    {
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
