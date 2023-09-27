using BookStore.Core.Contexts.ProductContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Contexts.ProductContext.Mappings;

public class BookMap : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Book");
        builder.HasKey(book => book.Id);

        builder.Property(book => book.Title).HasColumnName("Title").HasColumnType("NVARCHAR").HasMaxLength(80).IsRequired(true);
        builder.Property(book => book.LaunchDate).HasColumnName("LaunchDate").HasColumnType("DATETIME").IsRequired(true);
        builder.Property(book => book.Description).HasColumnName("Description").HasColumnType("NVARCHAR").HasMaxLength(500).IsRequired(true);
        builder.Property(book => book.Price).HasColumnName("Price").HasColumnType("DECIMAL").IsRequired(true);

        builder.HasOne(book => book.Publisher).WithMany(publisher => publisher.Books);

        builder.HasMany(book => book.Authors).WithMany(author => author.Books).UsingEntity<Dictionary<string, object>>(
            "BookAuthor",
            author => author.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.Cascade),
            book => book.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.Cascade));

        builder.HasMany(book => book.Genres).WithMany(genre => genre.Books).UsingEntity<Dictionary<string, object>>(
            "BookGenre",
            genre => genre.HasOne<Genre>().WithMany().HasForeignKey("GenreId").OnDelete(DeleteBehavior.Cascade),
            book => book.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.Cascade));
    }
}
