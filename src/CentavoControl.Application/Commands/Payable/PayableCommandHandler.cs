using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Commands.Payable;

public class PayableCommandHandler(IPayableRepository repository) : IPayableCommandHandler
{
    public async Task<PayableViewModel> AddPayableAsync(AddPayableCommand command, CancellationToken cancellationToken)
    {
        var payable = command.ToEntity("0741789C-C8B4-468F-BE98-CC7569D85918");
        await repository.AddAsync(payable, cancellationToken);
        PayableViewModel payableViewModel = new(payable.Id, payable.Description, payable.Amount, payable.DueDate, payable.IsPaid);
        return payableViewModel;
    }

    public async Task<PayableViewModel> UpdatePayableAsync(UpdatePayableCommand command, CancellationToken cancellationToken)
    {
        var payable = await repository.GetByIdAsync(command.GetPayableId(), cancellationToken);
        payable?.UpdateDetails(command.Description, command.Amount, command.DueDate, command.AccountId, command.CategoryId);
        await repository.UpdateAsync(payable!, cancellationToken);
        PayableViewModel updatedPayable = new(payable!.Id, payable.Description, payable.Amount, payable.DueDate, payable.IsPaid);
        return updatedPayable;
    }

    public async Task DeletePayableAsync(DeletePayableCommand command, CancellationToken cancellationToken)
    {
        var payable = await repository.GetByIdAsync(command.Id, cancellationToken);
        await repository.DeleteAsync(payable!.Id, cancellationToken);
    }

    public async Task MarkAsPaidAsync(MarkPayableAsPaidCommand command, CancellationToken cancellationToken)
    {
        var payable = await repository.GetByIdAsync(command.Id, cancellationToken);
        payable?.MarkAsPaid();
        await repository.UpdateAsync(payable!, cancellationToken);
    }
}