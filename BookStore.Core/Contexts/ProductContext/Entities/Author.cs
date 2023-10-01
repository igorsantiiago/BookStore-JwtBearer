using BookStore.Core.Contexts.SharedContext.Entities;
using BookStore.Core.Contexts.SharedContext.ValueObjects;

namespace BookStore.Core.Contexts.ProductContext.Entities;

public class Author : Entity
{
    protected Author() { }
    public Author(Name name, DateTime birthDate)
    {
        Name = name;
        BirthDate = birthDate;
    }

    public Name Name { get; private set; } = null!;
    public DateTime BirthDate { get; private set; }
    public List<Book> Books { get; private set; } = new();

    public void ChangeName(string firstName, string lastName)
    {
        Name.FirstName = firstName;
        Name.LastName = lastName;
    }
    public void ChangeBirthDate(DateTime birthDate) => BirthDate = birthDate;
}
