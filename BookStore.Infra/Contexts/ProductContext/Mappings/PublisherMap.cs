using BookStore.Core.Contexts.ProductContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Contexts.ProductContext.Mappings;

public class PublisherMap : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("Publishers");
        builder.HasKey(publisher => publisher.Id);

        builder.Property(publisher => publisher.Name).HasColumnName("Name").HasColumnType("NVARCHAR").HasMaxLength(80).IsRequired(true);
    }
}