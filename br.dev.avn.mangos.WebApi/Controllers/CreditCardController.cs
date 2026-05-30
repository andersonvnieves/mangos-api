using System.Security.Claims;
using br.dev.avn.mangos.Application.UseCases.CreditCard;
using br.dev.avn.mangos.Application.UseCases.CreditCard.ListRecentTransactions;
using br.dev.avn.mangos.Application.UseCases.CreditCard.RetrieveCCTransaction;
using Microsoft.AspNetCore.Mvc;

namespace br.dev.avn.mangos.WebApi.Controllers;

[Route("[controller]")]
public class CreditCardController : ControllerBase
{
    private readonly RegisterCCTRansactionUseCase _registerCCTRansactionUseCase;
    private readonly RetrieveCCTransactionUseCase _retrieveCCTransactionUseCase;
    private readonly ListRecentTransactionsUseCase _listRecentTransactionsUseCase;

    public CreditCardController(RegisterCCTRansactionUseCase registerCCTRansactionUseCase, 
        RetrieveCCTransactionUseCase retrieveCCTransactionUseCase, 
        ListRecentTransactionsUseCase listRecentTransactionsUseCase)
    {
        _registerCCTRansactionUseCase = registerCCTRansactionUseCase;
        _retrieveCCTransactionUseCase = retrieveCCTransactionUseCase;
        _listRecentTransactionsUseCase = listRecentTransactionsUseCase;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userId = User.FindFirstValue("sub");
        var response =
            await _listRecentTransactionsUseCase.ExecuteAsync(
                new ListRecentTransactionsRequest
                {
                    UserId = userId
                });

        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var response =
            await _retrieveCCTransactionUseCase.ExecuteAsync(new RetrieveCCTransactionRequest() { TransactionId = id });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RegisterCCTRansactionRequest request)
    {
        var response = await _registerCCTRansactionUseCase.ExecuteAsync(request);
        return Ok(response);
    }
}