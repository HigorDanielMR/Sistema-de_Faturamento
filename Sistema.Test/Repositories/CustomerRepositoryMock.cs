using System.Infra.Repositories;
using System.Domain.Interfaces;
using System.Domain.Entities;

namespace System.Test.Repositories;

public class CustomerRepositoryMock : IRepository<Customer>
{
    private int _novoID = 1;
    private List<Customer> _repository = Singleton.Instance.CustomerRepository;

    public async Task<Customer> Create(Customer customer)
    {
        customer.ID = _novoID;
        _novoID++;
        _repository.Add(customer);

        return customer;
    }

    public async Task<List<Customer>> GetAll()
    {
        return _repository;
    }

    public async Task<Customer> GetID(int customerId)
    {
        var customerDb = _repository.Find(customer => customer.ID == customerId);

        return customerDb ?? throw new Exception($"Customer with ID {customerDb} not found.");
    }

    public async void Remove(int customerId)
    {
        var customerDb = await GetID(customerId);

        _repository.Remove(customerDb);
    }

    public async Task<Customer> Update(Customer updatedClient)
    {
        var customerDb = await GetID(updatedClient.ID);
        var index = _repository.FindIndex(customer => customer.ID == updatedClient.ID);

        customerDb.PersonType = updatedClient.PersonType;
        customerDb.Payments = updatedClient.Payments;
        customerDb.CNPJ = updatedClient.CNPJ;
        customerDb.Name = updatedClient.Name;
        customerDb.CPF = updatedClient.CPF;

        _repository.Insert(index, customerDb);

        return customerDb;

    }
}
