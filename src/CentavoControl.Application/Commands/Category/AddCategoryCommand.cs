namespace CentavoControl.Application.Commands.Category;

public class AddCategoryCommand(string name, string type)
{
    public string Name { get; private set; } = name;
    public string Type { get; private set; } = type;
    
    public Domain.Entities.Category ToEntity(string userId) => new(Guid.NewGuid(), Name, Enum.Parse<Domain.Enums.ETransactionType>(Type), userId);
}