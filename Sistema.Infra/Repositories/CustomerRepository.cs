using System.Domain.Validations;
using System.Infra.DBConnection;
using System.Domain.Interfaces;
using System.Domain.Entities;
using LinqToDB;

namespace System.Infra.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    private CustomerValidation _customerValidation;
    private Connection _connection;

    public CustomerRepository(Connection connection, CustomerValidation customerValidation)
    {
        _customerValidation = customerValidation;
        _connection = connection;
    }

    public async Task<Customer> Create(Customer customer)
    {
        customer.ID = _connection.InsertWithInt32Identity(customer);

        return customer;
    }

    public async Task<List<Customer>> GetAll()
    {
        var query = from customer in _connection.Customers
                    where customer.ID > 0
                    select customer;

        return query.ToList();
    }

    public async Task<Customer> GetID(int itemId)
    {
        var query = from customer in _connection.Customers
                    where customer.ID == itemId
                    select customer;

        return query.FirstOrDefault() ?? throw new Exception($"Customer with ID {itemId} not found.");
    }

    public async void Remove(int removalId)
    {
        var customerDb = await GetID(removalId);

        _connection.Delete(customerDb);
    }

    public async Task<Customer> Update(Customer customer)
    {
        var customerDb = await GetID(customer.ID);

        customerDb.Name = customer.Name;
        customerDb.CPF = customer.CPF;
        customerDb.CNPJ = customer.CNPJ;
        customerDb.Payments = customer.Payments;
        customerDb.PersonType = customer.PersonType;

        _connection.Update(customerDb);

        return customerDb;
    }
}
