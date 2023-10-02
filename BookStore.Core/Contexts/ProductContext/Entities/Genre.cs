using BookStore.Core.Contexts.SharedContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.Entities;

public class Genre : Entity
{
    protected Genre() { }
    public Genre(string name)
    {
        Name = name;
    }
    public string Name { get; private set; } = string.Empty;
    public List<Book> Books { get; set; } = new();

    public void UpdateName(string name) => Name = name;
}
