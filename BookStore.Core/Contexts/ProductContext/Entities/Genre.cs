using BookStore.Core.Contexts.SharedContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.Entities;

public class Genre : Entity
{
    protected Genre() { }
    public Genre(string genreName)
    {
        GenreName = genreName;
    }
    public string GenreName { get; private set; } = string.Empty;
    public List<Book> Books { get; set; } = new();

    public void ChangeName(string genreName) => GenreName = genreName;
}
