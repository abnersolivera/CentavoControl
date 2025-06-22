using CentavoControl.Domain.Commands.Account;
using CentavoControl.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Http.Extensions;

namespace CentavoControl.Controllers;

/// <summary>
/// Controlador de conta para gerenciar operações relacionadas à conta do usuário.
/// </summary>
[Route("[controller]")]
[ApiController]
public class AccountController(IAccountApplication handler) : Controller
{
    /// <summary>
    /// Obtém uma conta pelo ID.
    /// </summary>
    /// <param name="id"/>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById([FromRoute] string id)
    {
        var command = new GetAccountByIdCommand();
        command.SetId(id);
        return Ok(await handler.GetAccountByIdAsync(command));
    }
    
    /// <summary>
    /// Obtém uma lista de contas associadas a um usuário específico pelo ID do usuário.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetAccountsByUserId([FromRoute] string userId)
    {
        var command = new GetAccountsByUserIdCommand();
        command.SetUserId(userId);
        return Ok(await handler.GetAccountsByUserIdAsync(command));
    }
    
    /// <summary>
    /// Adiciona uma nova conta com base nos dados fornecidos no comando.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddAccount([FromBody] AddAccountCommand command)
    {
        return Created(HttpContext.Request.GetDisplayUrl() , await handler.AddAccountAsync(command));
    }
    
    /// <summary>
    /// Atualiza uma conta existente com base no ID fornecido e nos dados do comando.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAccount([FromRoute] string id, [FromBody] UpdateAccountCommand command)
    {
        command.SetAccountId(id);
        return Ok(await handler.UpdateAccountAsync(command));
    }
    
    /// <summary>
    /// Exclui uma conta com base no ID fornecido.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount([FromRoute] string id)
    {
        var command = new DeleteAccountCommand();
        command.SetAccountId(id);
        await handler.DeleteAccountAsync(command);
        return Ok();
    }
    
}