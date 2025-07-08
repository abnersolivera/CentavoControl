using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Commands.Account;

public interface IAccountCommand
{
    Task<AccountViewModel> AddAccountAsync(AddAccountCommand command, CancellationToken cancellationToken);
    Task<AccountViewModel> UpdateAccountAsync(UpdateAccountCommand command, CancellationToken cancellationToken);
    Task DeleteAccountAsync(DeleteAccountCommand command, CancellationToken cancellationToken);
}