namespace CentavoControl.Controllers;

/// <summary>
/// Controlador de conta para gerenciar operações relacionadas à conta do usuário.
/// </summary>
[Route("[controller]")]
[ApiController]
public class AccountController(IAccountCommandHandeler handler, IAccountQueryHandler queryHandler, IAccountRepository repository, ILogger<AccountController> logger) : Controller
{
    /// <summary>
    /// Obtém uma conta pelo ID.
    /// </summary>
    /// <param name="id"/>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById([FromRoute] string id, CancellationToken cancellationToken)
    {
        var command = new GetAccountByIdQuery();
        command.SetId(id);
        return Ok(await queryHandler.GetAccountByIdAsync(command, cancellationToken));
    }

    /// <summary>
    /// Obtém uma lista de contas associadas a um usuário específico pelo ID do usuário.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetAccountsByUserId([FromRoute] string userId, CancellationToken cancellationToken)
    {
        var command = new GetAccountsByUserIdQuery();
        command.SetUserId(userId);
        return Ok(await queryHandler.GetAccountsByUserIdAsync(command, cancellationToken));
    }

    /// <summary>
    /// Adiciona uma nova conta com base nos dados fornecidos no comando.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddAccount([FromBody] AddAccountCommand command, CancellationToken cancellationToken)
    {
        var validator = new AddAccountCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors[0].ErrorMessage);
        logger.LogInformation("Adding new account with name: {Name}", command.Name);
        return Created(HttpContext.Request.GetDisplayUrl() , await handler.AddAccountAsync(command, cancellationToken));
    }

    /// <summary>
    /// Atualiza uma conta existente com base no ID fornecido e nos dados do comando.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAccount([FromRoute] string id, [FromBody] UpdateAccountCommand command, CancellationToken cancellationToken)
    {
        command.SetAccountId(id);
        var validator = new UpdateAccountCommandValidator(repository);
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors[0].ErrorMessage);
        return Ok(await handler.UpdateAccountAsync(command, cancellationToken));
    }

    /// <summary>
    /// Exclui uma conta com base no ID fornecido.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount([FromRoute] string id, CancellationToken cancellationToken)
    {
        var command = new DeleteAccountCommand();
        command.SetAccountId(id);
        await handler.DeleteAccountAsync(command, cancellationToken);
        return Ok();
    }
    
}