using System.Domain.Entities;
using LinqToDB.Data;
using LinqToDB;

namespace System.Infra.DBConnection;

public class Connection : DataConnection
{
    public Connection(string stringDeConexao) : base("SqlServer", stringDeConexao) { }

    public ITable<Customer> Customers => this.GetTable<Customer>();
    public ITable<Invoice> Invoices => this.GetTable<Invoice>();
}