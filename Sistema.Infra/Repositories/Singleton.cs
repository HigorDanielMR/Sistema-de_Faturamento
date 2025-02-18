using System.Domain.Entities;

namespace System.Infra.Repositories;

public sealed class Singleton
{
    private static readonly Lazy<Singleton> _instance =
        new Lazy<Singleton>(() => new Singleton());

    public List<Customer> CustomerRepository { get; } = new List<Customer>();
    public List<Invoice> InvoiceRepository { get; } = new List<Invoice>();

    private Singleton() { }

    public static Singleton Instance => _instance.Value;
}
