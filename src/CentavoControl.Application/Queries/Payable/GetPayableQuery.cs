namespace CentavoControl.Application.Queries.Payable;

public record GetPayableQuery(
    Guid? Id,
    Guid? CategoryId,
    Guid? AccountId,
    bool IsPaid = false,
    int Page = 1,
    int Rows = 10
);