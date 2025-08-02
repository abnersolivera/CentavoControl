using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Queries.Payable;

public class PayableQueryHandler(IPayableRepository repository) : IPayableQueryHandler
{
    public async Task<PayableViewModel?> GetPayableByIdAsync(GetPayableByIdQuery query,
        CancellationToken cancellationToken)
    {
        var payable = await repository.GetByIdAsync(query.Id, cancellationToken);
        if (payable == null) return null;
        var payableViewModel = new PayableViewModel(payable.Id, payable.Description, payable.Amount, payable.DueDate,
            payable.IsPaid);
        return payableViewModel;
    }

    public async Task<IEnumerable<PayableViewModel>> GetPayablesByAccountIdAsync(GetPayableByAccountIdQuery query,
        CancellationToken cancellationToken)
    {
        var userId = "0741789C-C8B4-468F-BE98-CC7569D85918";
        var payables = await repository.GetByAccountIdAsync(query.AccountId, userId, cancellationToken);
        var payableViewModels = payables.Select(payable => new PayableViewModel(
            payable.Id,
            payable.Description,
            payable.Amount,
            payable.DueDate,
            payable.IsPaid
        ));
        return payableViewModels;
    }

    public async Task<IEnumerable<PayableViewModel>> GetPayablesByCategoryIdAsync(GetPayableByCategoryIdQuery query,
        CancellationToken cancellationToken)
    {
        var userId = "0741789C-C8B4-468F-BE98-CC7569D85918";
        var payables = await repository.GetByCategoryIdAsync(query.CategoryId, userId, cancellationToken);
        var payableViewModels = payables.Select(payable => new PayableViewModel(
            payable.Id,
            payable.Description,
            payable.Amount,
            payable.DueDate,
            payable.IsPaid
        ));
        return payableViewModels;
    }

    public async Task<IEnumerable<PayableViewModel>> GetAllPayablesAsync(GetPayableByUserIdQuery query,
        CancellationToken cancellationToken)
    {
        var payables = await repository.GetByUserIdAsync(query.UserId, cancellationToken);
        var payableViewModels = payables.Select(payable => new PayableViewModel(
            payable.Id,
            payable.Description,
            payable.Amount,
            payable.DueDate,
            payable.IsPaid
        ));
        return payableViewModels;
    }
}