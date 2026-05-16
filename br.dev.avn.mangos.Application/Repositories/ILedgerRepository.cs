using br.dev.avn.mangos.Application.UseCases.CreditCard;
using br.dev.avn.mangos.Domain.Entities;

namespace br.dev.avn.mangos.Application.Repositories;

public interface ILedgerRepository
{
    Task  CreateCardTransaction(CreditCardTransaction transaction);
}