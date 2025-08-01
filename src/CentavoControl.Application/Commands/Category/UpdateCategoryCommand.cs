using CentavoControl.Domain.Enums;

namespace CentavoControl.Application.Commands.Category;

public class UpdateCategoryCommand(string name, string type)
{
    private Guid _id;
    public string Name { get; private set; } = name;
    public string Type { get; private set; } = type;
    
    public void SetCategoryId(string categoryId) => _id = Guid.Parse(categoryId);
    public Guid GetCategoryId() => _id;
    public ETransactionType ParseType() => Enum.Parse<ETransactionType>(Type);
}