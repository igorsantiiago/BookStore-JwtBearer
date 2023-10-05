using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.ProductContext.Entities;
using BookStore.Infra.Contexts.EmployeeContext.Mappings;
using BookStore.Infra.Contexts.ProductContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeMap());
        modelBuilder.ApplyConfiguration(new RoleMap());

        modelBuilder.ApplyConfiguration(new AuthorMap());
        modelBuilder.ApplyConfiguration(new GenreMap());
        modelBuilder.ApplyConfiguration(new PublisherMap());
        modelBuilder.ApplyConfiguration(new BookMap());
    }
}
