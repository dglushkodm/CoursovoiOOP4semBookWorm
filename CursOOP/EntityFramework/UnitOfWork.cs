using EntityFramework.Models;
using EntityFramework.Repositories;
using EntityFramework.Services;

namespace EntityFramework;

public class UnitOfWork : IDisposable
{
    public IRepository<Book> Books { get; set; }
    public IRepository<User> Users { get; set; }
    public IRepository<UserBook> UserBooks { get; set; }
    public IRepository<Review> Reviews { get; set; }
    public IRepository<Chapter> Chapters { get; set; }
    public IRepository<Genre> Genres{ get; set; }
    public IRepository<BookRate> BookRates { get; set; }
    
    public UnitOfWork()
    {
        var db = new CursOOPDbContext();
        
        Books = new BaseRepository<Book>(db);
        Users = new BaseRepository<User>(db);
        UserBooks = new BaseRepository<UserBook>(db);
        Reviews = new BaseRepository<Review>(db);
        Chapters = new BaseRepository<Chapter>(db);
        Genres = new BaseRepository<Genre>(db);
        BookRates= new BaseRepository<BookRate>(db);
        
    }
    
    public void Dispose()
    {
        
    }
}