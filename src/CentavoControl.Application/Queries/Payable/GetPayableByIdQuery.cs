namespace CentavoControl.Application.Queries.Payable;

public class GetPayableByIdQuery(Guid id)
{
    public Guid Id { get; private set; } = id;
}