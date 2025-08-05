using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Queries.Payable;

public class PayableQueryHandler(IPayableRepository repository) : IPayableQueryHandler
{
    public async Task<IEnumerable<PayableViewModel>?> GetPayableAsync(GetPayableQuery query,
        CancellationToken cancellationToken)
    {
        var userId = "";

        var payable = (await repository.GetByFiltersAsync(query.Id, query.AccountId, query.CategoryId,
            userId, query.IsPaid, query.Page, query.Rows, cancellationToken)).ToList();
        if (payable.Count == 0) return [];
        var payableViewModel = payable.Select(p => new PayableViewModel(p.Id, p.Description, p.Amount, p.DueDate,
            p.IsPaid));
        return payableViewModel;
    }
}