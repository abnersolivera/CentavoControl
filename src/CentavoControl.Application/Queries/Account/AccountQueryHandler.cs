using CentavoControl.Application.Commands.Account;
using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Queries.Account;

public class AccountQueryHandler(IAccountRepository repository) : IAccountQuery
{
    public async Task<AccountViewModel?> GetAccountByIdAsync(GetAccountByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await repository.GetByIdAsync(query.GetId(), cancellationToken);

        if (result != null)
        {
            AccountViewModel account = new (result.Id, result.Name, result.InitialBalance, result.IsMainAccount, result.UserId);
        
            return account;
        }
        return null;
    }

    public async Task<IEnumerable<AccountViewModel>> GetAccountsByUserIdAsync(GetAccountsByUserIdQuery query, CancellationToken cancellationToken)
    {
        var result = await repository.GetByUserIdAsync(query.GetUserId(), cancellationToken);
        
        List<AccountViewModel> accounts = result.Select(x => new AccountViewModel(x.Id, x.Name, x.InitialBalance, x.IsMainAccount, x.UserId)).ToList();
        
        return accounts;
    }
}