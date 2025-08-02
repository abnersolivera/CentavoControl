using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Queries.Payable;

public interface IPayableQueryHandler
{
    Task<PayableViewModel?> GetPayableByIdAsync(GetPayableByIdQuery query, CancellationToken cancellationToken);
    Task<IEnumerable<PayableViewModel>> GetPayablesByAccountIdAsync(GetPayableByAccountIdQuery query, CancellationToken cancellationToken);
    Task<IEnumerable<PayableViewModel>> GetPayablesByCategoryIdAsync(GetPayableByCategoryIdQuery query, CancellationToken cancellationToken);
    Task<IEnumerable<PayableViewModel>> GetAllPayablesAsync(GetPayableByUserIdQuery query, CancellationToken cancellationToken);
}