namespace CentavoControl.Application.Commands.Category;

public class DeleteCategoryCommand
{
    private Guid _id;

    public void SetCategoryId(string accountId) => _id = Guid.Parse(accountId);
    public Guid GetCategoryId() => _id;
}