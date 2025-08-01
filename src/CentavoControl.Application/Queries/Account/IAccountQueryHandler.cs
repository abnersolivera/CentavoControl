using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Queries.Account;

public interface IAccountQueryHandler
{
    Task<AccountViewModel?> GetAccountByIdAsync(GetAccountByIdQuery query, CancellationToken cancellationToken);
    Task<IEnumerable<AccountViewModel>> GetAccountsByUserIdAsync(GetAccountsByUserIdQuery query, CancellationToken cancellationToken);
}