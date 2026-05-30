using br.dev.avn.mangos.Application.Repositories;

namespace br.dev.avn.mangos.Application.UseCases.CreditCard.ListRecentTransactions;

public class ListRecentTransactionsUseCase
{
    private readonly ILedgerRepository  _ledgerRepository;
    
    public ListRecentTransactionsUseCase(ILedgerRepository  ledgerRepository)
    {
        _ledgerRepository = ledgerRepository;
    }

    public async Task<ListRecentTransactionsResponse> ExecuteAsync(ListRecentTransactionsRequest  request)
    {
        var response = await _ledgerRepository.GetUserTransactions(request.UserId);
        return new ListRecentTransactionsResponse() { data = response };
    }
}