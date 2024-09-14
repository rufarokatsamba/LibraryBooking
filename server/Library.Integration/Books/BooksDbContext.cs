using Library.Domain.Books;
using Library.Integration.Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Integration.Books;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<SqlBookModel> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("LibraryDatabase", 
                b => b.MigrationsAssembly("Library.WebHost")); // Set the assembly here
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SqlBookModel>().HasData(SeedBooks);
    }

    private static readonly SqlBookModel[] SeedBooks =
    {
        new() {Id = Guid.NewGuid(), Author = "Book 1 Author", Available = 1,BookName = "Book 1", Publisher = "Book 1 Publishers",Category = 0,Edition = "First Edition",Isbn = "123"},
        new() {Id = Guid.NewGuid(), Author = "Book 2 Author", Available = 1,BookName = "Book 2", Publisher = "Book 2 Publishers",Category = 0,Edition = "First Edition",Isbn = "1234"}
    };
}