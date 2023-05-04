namespace Chat.Database.Interface;

public interface IBaseRepository<T>
{
    Task<int> Create(T entity);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<int> DeleteById(int id);
    Task<int> Update(T entity);
}