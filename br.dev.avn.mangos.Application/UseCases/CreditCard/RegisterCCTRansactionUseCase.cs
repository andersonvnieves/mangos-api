using br.dev.avn.mangos.Application.Repositories;
using br.dev.avn.mangos.Domain.Entities;
using NUlid;

namespace br.dev.avn.mangos.Application.UseCases.CreditCard;

public class RegisterCCTRansactionUseCase
{
    private readonly ILedgerRepository _ledgerRepository;

    public RegisterCCTRansactionUseCase(ILedgerRepository ledgerRepository)
    {
        _ledgerRepository = ledgerRepository;
    }

    public async Task<RegisterCCTRansactionResponse> ExecuteAsync(RegisterCCTRansactionRequest request)
    {

        var transaction = new CreditCardTransaction()
        {
            TransactionId = Ulid.NewUlid().ToString(),
            UserId = Guid.NewGuid().ToString(),
            Value = request.Value,
            CreatedAt = request.CreatedAt,
        };
        
        await _ledgerRepository.CreateCardTransaction(transaction);

        return new RegisterCCTRansactionResponse();
    }
}