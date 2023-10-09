using BookStore.Core.Contexts.EmployeeContext.UseCases.Delete;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Delete.Contracts;

namespace BookStore.Core.Tests.Contexts.EmployeeContext.UseCases.Delete;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;
    private readonly Request _validRequest = new(new Guid("4c6a9c4a-ff72-499e-9e69-c6bfa0d23b2e"), "test@example.com");
    private readonly Request _invalidEmailRequest = new(Guid.NewGuid(), "testexample.com");
    private readonly Request _invalidEmployee = new(Guid.NewGuid(), "notemployee@example.com");
    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new(_repository);
    }

    #region Should_Fail
    [Fact]
    public void Should_Fail_When_Request_Email_Is_Invalid()
    {
        var response = Specification.Validate(_invalidEmailRequest);
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
    public async void Should_Succeed_When_Employee_Found()
    { 
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }

    [Fact]
    public async void Should_Succeed_When_Data_Persist()
    {
        var response = await _handler.Handle(_validRequest, new CancellationToken());
        Assert.True(response.IsSuccess);
    }
    #endregion
}
