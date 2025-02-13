namespace Sistema.Domain.Entities;

public class Customer
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime LastPaymentDate { get; set; }
    public List<Invoice> Payments { get; set; }
}
