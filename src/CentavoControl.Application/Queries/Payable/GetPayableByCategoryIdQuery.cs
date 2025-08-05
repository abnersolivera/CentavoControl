namespace CentavoControl.Application.Queries.Payable;

public class GetPayableByCategoryIdQuery(Guid categoryId)
{
    public Guid CategoryId { get; private set; } = categoryId;
}