using CentavoControl.Domain.Enums;

namespace CentavoControl.Application.Queries.Category;

public class GetCategoryByTypeAndUserIdQuery(string userId, string type)
{
    private string UserId { get; set; } = userId;
    private string Type { get; set; } = type;

    public string GetUserId() => UserId;
    
    public string GetType() => Type;
}