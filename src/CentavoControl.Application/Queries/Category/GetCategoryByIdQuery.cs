namespace CentavoControl.Application.Queries.Category;

public class GetCategoryByIdQuery
{
    private Guid _id;
    public void SetId(string id) => _id = Guid.Parse(id);
    public Guid GetId() => _id;
}