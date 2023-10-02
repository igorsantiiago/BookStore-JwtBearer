using BookStore.Core.Contexts.SharedContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.Entities;

public class Publisher : Entity
{
    protected Publisher() { }
    public Publisher(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = string.Empty;
    public List<Book> Books { get; private set; } = new();

    public void UpdateName(string name) => Name = name;
}
