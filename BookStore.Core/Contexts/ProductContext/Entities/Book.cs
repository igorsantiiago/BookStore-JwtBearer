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
    public List<Author> Author { get; private set; } = new();
    public Publisher Publisher { get; private set; } = null!;
    public List<Genre> Genre { get; private set; } = new();

    public void ChangeTitle(string title) => Title = title;
    public void ChangeLaunch(DateTime launchDate) => LaunchDate = launchDate;
    public void ChangeDescription(string description) => Description = description;
    public void ChangePrice(decimal price) => Price = price;

    public void AddAuthor(Author author) => Author.Add(author);
    public void AddGenre(Genre genre) => Genre.Add(genre);
    public void AddPublisher(Publisher publisher) => Publisher = publisher;
}
