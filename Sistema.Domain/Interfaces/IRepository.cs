namespace System.Domain.Interfaces;

public interface IRepository<T>
{
    Task<List<T>> GetAll();
    Task<T> Create(T obj);
    Task<T> GetID(int ItemId);
    Task<T> Update(T obj);
    void Remove(int RemovalId);
}
