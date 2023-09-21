using BookStore.Core.Contexts.EmployeeContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Contexts.EmployeeContext.Mappings;

public class EmployeeMap : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");
        builder.HasKey(employee => employee.Id);

        builder.OwnsOne(employee => employee.Name)
            .Property(name => name.FirstName).HasColumnType("NVARCHAR").HasColumnName("FirstName").HasMaxLength(50).IsRequired(true);
        builder.OwnsOne(employee => employee.Name)
            .Property(name => name.LastName).HasColumnType("NVARCHAR").HasColumnName("LastName").HasMaxLength(50).IsRequired(true);
        builder.Property(employee => employee.BirthDate).HasColumnType("DATETIME").HasColumnName("BirthDate").IsRequired(true);
        builder.OwnsOne(employee => employee.Email)
            .Property(email => email.Address).HasColumnType("VARCHAR").HasColumnName("Email").HasMaxLength(255).IsRequired(true);
        builder.OwnsOne(employee => employee.Password)
            .Property(password => password.Hash).HasColumnName("PasswordHash").HasMaxLength(255).IsRequired();

        builder.HasMany(employee => employee.Roles).WithMany(roles => roles.Employees).UsingEntity<Dictionary<string, object>>(
            "EmployeeRole",
            role => role.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.Cascade),
            employee => employee.HasOne<Employee>().WithMany("EmployeeId").OnDelete(DeleteBehavior.Cascade)
            );
    }
}
