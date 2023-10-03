using BookStore.Core.Contexts.SharedContext.Entities;

namespace BookStore.Core.Contexts.ProductContext.Entities;

public class Book : Entity
{
    protected Book() { }
    public Book(string title, DateTime launchDate, string description, decimal price)
    {
        Title = title;
        LaunchDate = launchDate;
        Description = description;
        Price = price;
    }

    public string Title { get; private set; } = string.Empty;
    public DateTime LaunchDate { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public List<Author> Authors { get; private set; } = new();
    public Publisher Publisher { get; private set; } = null!;
    public List<Genre> Genres { get; private set; } = new();

    public void UpdateTitle(string title) => Title = title;
    public void UpdateLaunchDate(DateTime launchDate) => LaunchDate = launchDate;
    public void UpdateDescription(string description) => Description = description;
    public void UpdatePrice(decimal price) => Price = price;

    public void AddAuthor(Author author) => Authors.Add(author);
    public void AddGenre(Genre genre) => Genres.Add(genre);
    public void AddPublisher(Publisher publisher) => Publisher = publisher;
}
