namespace CentavoControl.Controllers;

/// <summary>
/// Controlador de categoria para gerenciar operações relacionadas às categorias do usuário.
/// </summary>
[Route("[controller]")]
[ApiController]
public class CategoryController(ICategoryCommandHandler commandHandler, ICategoryQueryHandler queryHandler) : Controller
{
    /// <summary>
    /// Obtém uma categoria pelo ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] string id, CancellationToken cancellationToken)
    {
        var command = new GetCategoryByIdQuery();
        command.SetId(id);
        return Ok(await queryHandler.GetCategoryByIdAsync(command, cancellationToken));
    }

    /// <summary>
    /// Obtém uma lista de categorias associadas a um usuário específico pelo ID do usuário.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetCategoriesByUserId([FromRoute] string userId,
        CancellationToken cancellationToken)
    {
        var command = new GetCategoryByUserIdQuery();
        command.SetUserId(userId);
        return Ok(await queryHandler.GetCategoriesByUserIdAsync(command, cancellationToken));
    }

    /// <summary>
    /// Obtém uma lista de categorias buscando pelo tipo e ID do usuário.
    /// O tipo pode ser "Income" ou "Expense", representando categorias de receita ou despesa.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("Type/{type}/User/{userId}")]
    public async Task<IActionResult> GetCategoriesByTypeAndUserId([FromRoute] string type, [FromRoute] string userId,
        CancellationToken cancellationToken)
    {
        var command = new GetCategoryByTypeAndUserIdQuery(userId, type);
        return Ok(await queryHandler.GetCategoriesByTypeAndUserIdAsync(command, cancellationToken));
    }

    /// <summary>
    /// Adiciona uma nova categoria com base nos dados fornecidos no comando.
    /// O comando deve conter o nome da categoria e o tipo (por exemplo, "Income" ou "Expense").
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command,
        CancellationToken cancellationToken)
    {
        return Created(HttpContext.Request.GetDisplayUrl(),
            await commandHandler.AddCategoryAsync(command, cancellationToken));
    }

    /// <summary>
    /// Atualiza uma categoria existente com base no ID fornecido e nos dados do comando.
    /// O comando deve conter o nome da categoria e o tipo (por exemplo, "Income" ou "Expense").
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] string id, [FromBody] UpdateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        command.SetCategoryId(id);
        return Ok(await commandHandler.UpdateCategoryAsync(command, cancellationToken));
    }

    /// <summary>
    /// Exclui uma categoria existente com base no ID fornecido.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] string id, CancellationToken cancellationToken)
    {
        var command = new DeleteCategoryCommand();
        command.SetCategoryId(id);
        await commandHandler.DeleteCategoryAsync(command, cancellationToken);
        return NoContent();
    }
}