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
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetPayableById([FromQuery] GetPayableQuery query,
        CancellationToken cancellationToken)
    {
        var payable = await queryHandler.GetPayableAsync(query, cancellationToken);
        return Ok(payable);
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