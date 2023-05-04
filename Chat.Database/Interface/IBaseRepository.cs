namespace Chat.Database.Interface;

public interface IBaseRepository<T>
{
    bool Create(T entity);
    T GetById(int id);
    IEnumerable<T> GetAll();
    bool Delete(T entity);
}