using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Queries.Payable;

public interface IPayableQueryHandler
{
    Task<IEnumerable<PayableViewModel>?> GetPayableAsync(GetPayableQuery query, CancellationToken cancellationToken);
}