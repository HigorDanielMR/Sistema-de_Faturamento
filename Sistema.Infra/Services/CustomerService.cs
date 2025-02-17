using System.Domain.Interfaces;
using System.Domain.Entities;

namespace System.Infra.Services;

public class CustomerService :  IRepository<Customer>
{
    public List<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public Customer GetID(int ItemId)
    {
        throw new NotImplementedException();
    }

    public void Remove(int RemovalId)
    {
        throw new NotImplementedException();
    }

    public Customer Update(Customer obj)
    {
        throw new NotImplementedException();
    }

    public Customer Create(Customer obj)
    {
        throw new NotImplementedException();
    }
}
