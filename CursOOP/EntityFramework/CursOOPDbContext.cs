using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityFramework;

public class CursOOPDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserBook> UserBooks { get; set; }
    public DbSet<BookRate> BookRates { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Genre> Genres { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserBook>().HasKey("Id");
        modelBuilder.Entity<BookRate>().HasKey("Id");
        
        modelBuilder.Entity<Genre>()
            .HasMany(bg => bg.Books)
            .WithMany(b => b.Genres);
        
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Database=it_intern;Port=5432;User Id=postgres;Password=1234");
    }
}

