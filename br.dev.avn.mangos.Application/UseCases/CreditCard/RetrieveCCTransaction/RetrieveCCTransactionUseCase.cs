using br.dev.avn.mangos.Application.Repositories;

namespace br.dev.avn.mangos.Application.UseCases.CreditCard.RetrieveCCTransaction;

public class RetrieveCCTransactionUseCase
{
    private readonly ILedgerRepository _ledgerRepository;

    public RetrieveCCTransactionUseCase(ILedgerRepository ledgerRepository)
    {
        _ledgerRepository = ledgerRepository;
    }
    
    public async Task<RetrieveCCTransactionResponse> ExecuteAsync(RetrieveCCTransactionRequest request)
    {
        var transaction = await _ledgerRepository.GetCardTransaction(request.TransactionId);

        return new RetrieveCCTransactionResponse()
        {
            TransactionId = transaction.TransactionId,
            UserId = transaction.UserId,
            Value = transaction.Value,
            CreatedAt = transaction.CreatedAt,
        };
    }
}