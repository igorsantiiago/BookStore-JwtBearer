using BookStore.Core.Contexts.ProductContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Contexts.ProductContext.Mappings;

public class AuthorMap : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Author");
        builder.HasKey(author => author.Id);

        builder.OwnsOne(author => author.Name)
            .Property(name => name.FirstName).HasColumnName("FirstName").HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired(true);
        builder.OwnsOne(author => author.Name)
            .Property(name => name.LastName).HasColumnName("LastName").HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired(true);
        builder.Property(author => author.BirthDate).HasColumnName("BirthDate").HasColumnType("DATETIME").IsRequired(true);
    }
}
