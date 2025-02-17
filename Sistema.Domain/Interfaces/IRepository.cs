namespace System.Domain.Interfaces;

public interface IRepository<T>
{
    List<T> GetAll();
    T Create(T obj);
    T GetID(int ItemId);
    T Update(T obj);
    void Remove(int RemovalId);
}
