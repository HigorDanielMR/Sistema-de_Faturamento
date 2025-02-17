using System.Infra.DBConnection;
using System.Domain.Interfaces;
using System.Domain.Entities;
using System.Infra.Services;
using System.Domain.Validations;
using LinqToDB;

namespace System.Infra.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    private Connection _connection;
    private CustomerService _customerService;
    private CustomerValidation _customerValidation;

    public CustomerRepository(Connection connection, CustomerService customerService, CustomerValidation customerValidation)
    {
        _connection = connection;
        _customerService = customerService;
        _customerValidation = customerValidation;
    }

    public Customer Create(Customer customer)
    {
        customer.ID = _connection.InsertWithInt32Identity(customer);

        return customer;
    }

    public List<Customer> GetAll()
    {
        var query = from customer in _connection.Customers
                    where customer.ID > 0
                    select customer;

        return query.ToList();
    }

    public Customer GetID(int ItemId)
    {
        var query = from customer in _connection.Customers
                    where customer.ID == ItemId
                    select customer;

        return query.FirstOrDefault() ?? throw new Exception($"Customer with ID {ItemId} not found.");
    }

    public void Remove(int RemovalId)
    {
        throw new NotImplementedException();
    }

    public Customer Update(Customer obj)
    {
        throw new NotImplementedException();
    }
}
