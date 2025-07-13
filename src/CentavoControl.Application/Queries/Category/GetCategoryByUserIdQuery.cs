namespace CentavoControl.Application.Queries.Category;

public class GetCategoryByUserIdQuery
{
    private string _userId = string.Empty;
    public void SetUserId(string userId) => _userId = userId;
    public string GetUserId() => _userId;
}