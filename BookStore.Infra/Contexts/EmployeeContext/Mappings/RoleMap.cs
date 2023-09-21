using BookStore.Core.Contexts.EmployeeContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Contexts.EmployeeContext.Mappings;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(role => role.Id);

        builder.Property(role => role.Name).HasColumnName("Name").HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired(true);
    }
}
