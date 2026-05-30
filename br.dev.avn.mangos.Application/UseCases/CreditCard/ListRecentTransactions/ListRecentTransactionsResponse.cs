using br.dev.avn.mangos.Domain.Entities;

namespace br.dev.avn.mangos.Application.UseCases.CreditCard.ListRecentTransactions;

public class ListRecentTransactionsResponse
{
    public ICollection<CreditCardTransaction> data { get; set; }
}