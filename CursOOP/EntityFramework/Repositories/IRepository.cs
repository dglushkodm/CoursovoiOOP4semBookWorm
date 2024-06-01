namespace EntityFramework.Repositories;

public interface IRepository<T>
{
    void Create(T obj);
    void Update(T oldObj, T updObj);
    void Delete(T obj);
    List<T> Read();

}