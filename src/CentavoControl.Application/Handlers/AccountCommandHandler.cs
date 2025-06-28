namespace CentavoControl.Application.Handlers;

public class AccountCommandHandler(IAccountRepository repository) : IAccountApplication
{
    public async Task<AccountDto?> GetAccountByIdAsync(GetAccountByIdCommand command, CancellationToken cancellationToken)
    {
        var result = await repository.GetByIdAsync(command.GetId(), cancellationToken);

        if (result != null)
        {
            AccountDto account = new (result.Id, result.Name, result.InitialBalance, result.IsMainAccount, result.UserId);
        
            return account;
        }
        return null;
    }

    public async Task<IEnumerable<AccountDto>> GetAccountsByUserIdAsync(GetAccountsByUserIdCommand command, CancellationToken cancellationToken)
    {
        var result = await repository.GetByUserIdAsync(command.GetUserId(), cancellationToken);
        
        List<AccountDto> accounts = result.Select(x => new AccountDto(x.Id, x.Name, x.InitialBalance, x.IsMainAccount, x.UserId)).ToList();
        
        return accounts;
    }

    public async Task<AccountDto> AddAccountAsync(AddAccountCommand command, CancellationToken cancellationToken)
    {
        var newAccount = new Account(Guid.NewGuid(), command.Name, command.InitialBalance, command.IsMainAccount, "0741789C-C8B4-468F-BE98-CC7569D85918");
        await repository.AddAsync(newAccount, cancellationToken);
        
        AccountDto account = new(newAccount.Id, newAccount.Name, newAccount.InitialBalance, newAccount.IsMainAccount, newAccount.UserId);
        
        return account;
    }

    public async Task<AccountDto> UpdateAccountAsync(UpdateAccountCommand command, CancellationToken cancellationToken)
    {
        var account = await repository.GetByIdAsync(command.GetAccountId(), cancellationToken);
        
        account?.ChangeName(command.Name);

        if (account != null) await repository.UpdateAsync(account, cancellationToken);
        
        AccountDto updatedAccount = new(account.Id, account.Name, account.InitialBalance, account.IsMainAccount, account.UserId);
        
        return updatedAccount;
    }

    public async Task DeleteAccountAsync(DeleteAccountCommand command, CancellationToken cancellationToken)
    {
        var account = await repository.GetByIdAsync(command.GetAccountId(), cancellationToken);

        if (account != null) await repository.DeleteAsync(account, cancellationToken);
    }
}