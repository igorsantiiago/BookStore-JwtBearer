using BookStore.Core.Contexts.EmployeeContext.UseCases.Create;
using BookStore.Core.Contexts.EmployeeContext.UseCases.Create.Contracts;

namespace BookStore.Core.Tests.Contexts.EmployeeContext.UseCases.Create.Repositories;

public class HandlerTest
{
    private readonly IRepository _repository;
    private readonly Handler _handler;

    public HandlerTest()
    {
        _repository = new FakeRepository();
        _handler = new Handler(_repository);
    }

    [Fact]
    public async void Should_Fail_When_Email_Already_Exists()
    {
        var request = new Request("Igor", "Santiago", DateTime.UtcNow, "teste@example.com", "ASHsju9m)(&dhn87SN8");
        var response = await _handler.Handle(request, new CancellationToken());

        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Fail_When_FirstName_Is_Invalid()
    {
        var request = new Request("I", "Santiago", DateTime.UtcNow, "test@example.com", "ASHsju9m)(&dhn87SN8");
        var response = await _handler.Handle(request, new CancellationToken());

        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Fail_When_LastName_Is_Invalid()
    {
        var request = new Request("Igor", "S", DateTime.UtcNow, "test@example.com", "ASHsju9m)(&dhn87SN8");
        var response = await _handler.Handle(request, new CancellationToken());

        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Fail_When_Password_Is_Invalid()
    {
        var request = new Request("Igor", "Santiago", DateTime.UtcNow, "test@example.com", "ASHs");
        var response = await _handler.Handle(request, new CancellationToken());
        
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async void Should_Succeed_When_Valid()
    {
        var request = new Request("Igor", "Santiago", DateTime.UtcNow, "test@example.com", "ASHsju9m)(&dhn87SN8");
        var response = await _handler.Handle(request, new CancellationToken());

        Assert.True(response.IsSuccess);
    }
}
