using System.Infra.DBConnection;
using System.Domain.Validations;
using System.Domain.Interfaces;
using System.Domain.Entities;
using LinqToDB;

namespace System.Infra.Repositories;

public class InvoiceRepository : IRepository<Invoice>
{
    private InvoiceValidation _validation;
    private Connection _connection;

    public InvoiceRepository(InvoiceValidation validation, Connection connection)
    {
        _validation = validation;
        _connection = connection;
    }

    public async Task<Invoice> Create(Invoice invoice)
    {
        invoice.ID = _connection.InsertWithInt32Identity(invoice.ID);

        return invoice;
    }

    public async Task<List<Invoice>> GetAll()
    {
        var query = from invoice in _connection.Invoices
                    where invoice.ID > 0
                    select invoice;

        return query.ToList();
    }

    public async Task<Invoice> GetID(int itemId)
    {
        var query = from invoice in _connection.Invoices
                    where invoice.ID == itemId
                    select invoice;

        return query.FirstOrDefault() ?? throw new Exception($"Invoice with ID {itemId} not found.");
    }

    public async void Remove(int RemovalId)
    {
        var invoiceDb = await GetID(RemovalId);

        _connection.Delete(invoiceDb);
    }

    public async Task<Invoice> Update(Invoice invoice)
    {
        var invoiceDb = await GetID(invoice.ID);

        invoiceDb.Status = invoice.Status;
        invoiceDb.TotalValue = invoice.TotalValue;

        _connection.Update(invoiceDb);

        return invoiceDb;
    }
}
