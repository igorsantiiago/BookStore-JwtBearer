using BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData.Contracts;

namespace BookStore.Core.Tests.Contexts.EmployeeContext.UseCases.Update.UpdateEmployeeData;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;
    private readonly Request _validRequest = new("Igor", "Santiago", "test@example.com", "teste@exemplo.com");
    private readonly Request _invalidEmail = new("Igor", "Santiago", "testexample.com", "testeexemplo.com");
    private readonly Request _invalidEmployee = new("Igor", "Santiago", "testando@example.com", "teste@exemplo.com");

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
    public async void Should_Succeed_Update_Employee_Data()
    {
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
