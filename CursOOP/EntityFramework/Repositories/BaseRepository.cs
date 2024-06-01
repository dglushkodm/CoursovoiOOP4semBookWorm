using EntityFramework.Models;

namespace EntityFramework.Repositories;

public class BaseRepository<T> : IRepository<T> where T : Base
{
    private CursOOPDbContext db;

    public BaseRepository(CursOOPDbContext db)
    {
        this.db = db;
    }
    
    public void Create(T obj)
    {
        db.Set<T>().Add(obj);
        db.SaveChanges();
    }

    public void Update(T oldObj, T updObj)
    {
        var existingObj = db.Set<T>().ToList().Find(b => b.Id == oldObj.Id);
        if (existingObj != null)
        {
            db.Entry(existingObj).CurrentValues.SetValues(updObj);
            db.SaveChanges();
        }
    }

    public void Delete(T obj)
    {
        db.Set<T>().Remove(obj);
        db.SaveChanges();
    }

    public List<T> Read()
    {
        return db.Set<T>().ToList();
    }

}