namespace Chat.Database.Interface;

public interface IBaseRepository<T>
{
    Task<int> Create(T entity);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<int> Delete(T entity);
}