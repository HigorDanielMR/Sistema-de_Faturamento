using System.Domain.Entities;
using System.Domain.Interfaces;
using System.Infra.Repositories;

namespace System.Test.Repositories;

public class InvoiceRepositoryMock : IRepository<Invoice>
{
    private List<Invoice> _repository = Singleton.Instance.InvoiceRepository;
    public async Task<Invoice> Create(Invoice invoice)
    {
        _repository.Add(invoice);

        return invoice;
    }

    public async Task<List<Invoice>> GetAll()
    {
        var allCustomer = _repository.Where(invoice => invoice.ID > 0).ToList();

        return allCustomer;
    }

    public async Task<Invoice> GetID(int invoiceId)
    {
        var invoiceDb = _repository.Find(invoice => invoice.ID == invoiceId);

        return invoiceDb ?? throw new Exception($"Invoice with ID {invoiceId} not found.");
    }

    public async void Remove(int RemovalId)
    {
        var invoiceDb = await GetID(RemovalId);
        _repository.Remove(invoiceDb);
    }

    public async Task<Invoice> Update(Invoice updatedInvoice)
    {
        var invoiceDb = await GetID(updatedInvoice.ID);
        var index = _repository.FindIndex(customer => customer.ID == updatedInvoice.ID);

        invoiceDb.Status = updatedInvoice.Status;
        invoiceDb.TotalValue = updatedInvoice.TotalValue;

        _repository.Insert(index, invoiceDb);

        return invoiceDb;
    }
}
