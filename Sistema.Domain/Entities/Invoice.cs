using System.Domain.Enum;

namespace System.Domain.Entities;

public class Invoice
{
    public int ID { get; set; }
    public int ClientId { get; set; }
    public decimal TotalValue { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime ExpirationDate { get; set; }
}
