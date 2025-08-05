using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Commands.Account;

public class AccountCommandHandler(IAccountRepository repository) : IAccountCommandHandeler
{
    public async Task<AccountViewModel> AddAccountAsync(AddAccountCommand command, CancellationToken cancellationToken)
    {
        var newAccount = command.ToEntity("0741789C-C8B4-468F-BE98-CC7569D85918");
        await repository.AddAsync(newAccount, cancellationToken);
        AccountViewModel account = new(newAccount.Id, newAccount.Name, newAccount.InitialBalance, newAccount.IsMainAccount, newAccount.UserId);
        return account;
    }

    public async Task<AccountViewModel> UpdateAccountAsync(UpdateAccountCommand command, CancellationToken cancellationToken)
    {
        var account = await repository.GetByIdAsync(command.GetAccountId(), cancellationToken);
        account?.ChangeName(command.Name);
        if (account != null) await repository.UpdateAsync(account, cancellationToken);
        AccountViewModel updatedAccount = new(account.Id, account.Name, account.InitialBalance, account.IsMainAccount, account.UserId);
        return updatedAccount;
    }

    public async Task DeleteAccountAsync(DeleteAccountCommand command, CancellationToken cancellationToken)
    {
        var account = await repository.GetByIdAsync(command.GetAccountId(), cancellationToken);
        if (account != null) await repository.DeleteAsync(account, cancellationToken);
    }
}