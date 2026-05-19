namespace br.dev.avn.mangos.Domain.Entities;

public class CreditCardTransaction
{
    public string TransactionId { get; set; }
    public string UserId { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedAt { get; set; }
}