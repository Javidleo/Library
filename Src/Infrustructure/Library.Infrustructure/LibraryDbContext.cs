using Library.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Library.Infrustructure;
public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {

    }
    public DbSet<Admin> Admins { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<UserBook> UserBooks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}