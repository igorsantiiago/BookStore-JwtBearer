using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Infra.Contexts.EmployeeContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeMap());
    }
}
