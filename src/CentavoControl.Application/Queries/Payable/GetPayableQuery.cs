namespace CentavoControl.Application.Queries.Payable;

public class GetPayableQuery(
    Guid? id = null,
    Guid? categoryId = null,
    Guid? accountId = null,
    bool isPaid = false,
    int page = 1,
    int rows = 10)
{
    public Guid? Id { get; private set; } = id;
    public Guid? CategoryId { get; private set; } = categoryId;
    public Guid? AccountId { get; private set; } = accountId;
    public bool IsPaid { get; private set; } = isPaid;
    public int Page { get; private set; } = page;
    public int Rows { get; private set; } = rows;
}