using System.Infra.Repositories;
using System.Domain.Interfaces;
using System.Domain.Entities;

namespace System.Infra.Services;

public class CustomerService :  IRepository<Customer>
{
    private CustomerRepository _repository;

    public CustomerService(CustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Create(Customer customer)
    {
        var newCustomer = await _repository.Create(customer);

        return newCustomer;
    }

    public async Task<List<Customer>> GetAll()
    {
        var allCustomer = await _repository.GetAll();

        return allCustomer;
    }

    public async Task<Customer> GetID(int itemId)
    {
        var customerDb = await _repository.GetID(itemId);

        return customerDb;
    }

    public async void Remove(int removalId)
    {
        _repository.Remove(removalId);
    }

    public async Task<Customer> Update(Customer customer)
    {
        var customerDb = await _repository.Update(customer);

        return customerDb;
    }
}
