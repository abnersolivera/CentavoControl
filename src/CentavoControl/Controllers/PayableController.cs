using CentavoControl.Application.Commands.Payable;
using CentavoControl.Application.Queries.Payable;

namespace CentavoControl.Controllers;

/// <summary>
/// Controlador de contas a pagar para gerenciar operações relacionadas às contas a pagar do usuário.
/// </summary>
[Route("[controller]")]
[ApiController]
public class PayableController(IPayableCommandHandler commandHandler, IPayableQueryHandler queryHandler) : Controller
{
    /// <summary>
    /// Obtém uma conta a pagar pelo ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPayableById([FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetPayableByIdQuery(id);
        var payable = await queryHandler.GetPayableByIdAsync(command, cancellationToken);
        return Ok(payable);
    }
    
    /// <summary>
    /// Obtém uma lista de contas a pagar associadas a um usuário específico pelo ID do usuário.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetPayablesByUserId([FromRoute] string userId,
        CancellationToken cancellationToken)
    {
        var command = new GetPayableByUserIdQuery(userId);
        var payables = await queryHandler.GetAllPayablesAsync(command, cancellationToken);
        return Ok(payables);
    }
    
    /// <summary>
    /// Obtém uma lista de contas a pagar associadas a um usuário específico pelo ID da conta.
    /// </summary>
    /// <param name="accountId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("Account/{accountId:guid}")]
    public async Task<IActionResult> GetPayablesByAccountId([FromRoute] Guid accountId,
        CancellationToken cancellationToken)
    {
        var command = new GetPayableByAccountIdQuery(accountId);
        var payables = await queryHandler.GetPayablesByAccountIdAsync(command, cancellationToken);
        return Ok(payables);
    }
    
    /// <summary>
    /// Obtém uma lista de contas a pagar associadas a um usuário específico pelo ID da categoria.
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("Category/{categoryId:guid}")]
    public async Task<IActionResult> GetPayablesByCategoryId([FromRoute] Guid categoryId,
        CancellationToken cancellationToken)
    {
        var command = new GetPayableByCategoryIdQuery(categoryId);
        var payables = await queryHandler.GetPayablesByCategoryIdAsync(command, cancellationToken);
        return Ok(payables);
    }
    
    /// <summary>
    /// Adiciona uma nova conta a pagar com base nos dados fornecidos no comando.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddPayable([FromBody] AddPayableCommand command, CancellationToken cancellationToken)
    {
        var payable = await commandHandler.AddPayableAsync(command, cancellationToken);
        return Created(HttpContext.Request.GetDisplayUrl(), payable);
    }

    /// <summary>
    /// Atualiza uma conta a pagar existente com base nos dados fornecidos no comando.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdatePayable([FromBody] UpdatePayableCommand command,
        CancellationToken cancellationToken)
    {
        var updatedPayable = await commandHandler.UpdatePayableAsync(command, cancellationToken);
        return Ok(updatedPayable);
    }

    /// <summary>
    /// Atualiza uma conta a pagar como status pago.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("{id:guid}/MarkAsPaid")]
    public async Task<IActionResult> MarkAsPaid([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new MarkPayableAsPaidCommand(id);
        await commandHandler.MarkAsPaidAsync(command, cancellationToken);
        return NoContent();
    }
    
    /// <summary>
    /// Exclui uma conta a pagar com base no ID fornecido.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePayable([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new DeletePayableCommand(id);
        await commandHandler.DeletePayableAsync(command, cancellationToken);
        return NoContent();
    }
}