using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Commands.Payable;

public interface IPayableCommandHandler
{
    Task<PayableViewModel> AddPayableAsync(AddPayableCommand command, CancellationToken cancellationToken);
    Task<PayableViewModel> UpdatePayableAsync(UpdatePayableCommand command, CancellationToken cancellationToken);
    Task DeletePayableAsync(DeletePayableCommand command, CancellationToken cancellationToken);
    Task MarkAsPaidAsync(MarkPayableAsPaidCommand command, CancellationToken cancellationToken);
}