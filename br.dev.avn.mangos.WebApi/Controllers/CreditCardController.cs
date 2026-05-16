using br.dev.avn.mangos.Application.UseCases.CreditCard;
using Microsoft.AspNetCore.Mvc;

namespace br.dev.avn.mangos.WebApi.Controllers;

[Route("api/[controller]")]
public class CreditCardController : ControllerBase
{
    private readonly RegisterCCTRansactionUseCase _registerCCTRansactionUseCase;

    public CreditCardController(RegisterCCTRansactionUseCase registerCCTRansactionUseCase)
    {
        _registerCCTRansactionUseCase = registerCCTRansactionUseCase;
    }
    
    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RegisterCCTRansactionRequest request)
    {
        var response = await _registerCCTRansactionUseCase.ExecuteAsync(request);
        return Ok(response);
    }
}