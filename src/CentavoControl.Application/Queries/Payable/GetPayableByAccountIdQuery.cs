namespace CentavoControl.Application.Queries.Payable;

public class GetPayableByAccountIdQuery(Guid accountId)
{
    public Guid AccountId { get; private set; } = accountId;
}