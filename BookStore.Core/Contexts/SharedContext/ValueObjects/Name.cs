namespace BookStore.Core.Contexts.SharedContext.ValueObjects;

public class Name : ValueObject
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
