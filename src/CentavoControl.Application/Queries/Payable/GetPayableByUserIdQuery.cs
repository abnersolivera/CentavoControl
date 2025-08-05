namespace CentavoControl.Application.Queries.Payable;

public class GetPayableByUserIdQuery(string userId)
{
    public string UserId { get; private set; } = userId;
}