namespace br.dev.avn.mangos.Application.UseCases.CreditCard;

public class RegisterCCTRansactionResponse
{
    public string TransactionId { get; set; }
    public string UserId { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedAt { get; set; }
}