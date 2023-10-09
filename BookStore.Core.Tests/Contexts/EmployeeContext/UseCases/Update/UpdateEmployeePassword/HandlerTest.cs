using BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword.Contracts;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword;

namespace BookStore.Core.Tests.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeePassword;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;
    private readonly Request _invalidEmail = new("testexample.com", "SGFDHJ9Ugvfdnh9iu)(*&");
    private readonly Request _invalidEmployee = new("testando@example.com", "SGFDHJ9Ugvfdnh9iu)(*&");
    private readonly Request _validRequest = new("test@example.com", "SGFDHJ9Ugvfdnh9iu)(*&");

    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new Handler(_repository);
    }

    #region Should_Fail
    [Fact]
    public void Should_Fail_When_Request_Is_Invalid()
    {
        var response = Specification.Validate(_invalidEmail);
        Assert.False(response.IsValid);
    }

    [Fact]
    public async void Should_Fail_When_Employee_Not_Found()
    {
        var response = await _handler.Handle(_invalidEmployee, new CancellationToken());
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
    public async void Should_Succeed_When_Get_Employee_Returns_Employee()
    {
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }

    [Fact]
    public async void Should_Succeed_Update_Employee_Password()
    {
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
