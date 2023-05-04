namespace Chat.Database.Interface;

public interface IBaseRepository<T>
{
    bool Create(T entity);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    bool Delete(T entity);
}