namespace CentavoControl.Domain.Interfaces.Application;

public interface IAccountApplication
{
    Task<AccountDto?> GetAccountByIdAsync(GetAccountByIdCommand command, CancellationToken cancellationToken);
    Task<IEnumerable<AccountDto>> GetAccountsByUserIdAsync(GetAccountsByUserIdCommand command, CancellationToken cancellationToken);
    Task<AccountDto> AddAccountAsync(AddAccountCommand command, CancellationToken cancellationToken);
    Task<AccountDto> UpdateAccountAsync(UpdateAccountCommand command, CancellationToken cancellationToken);
    Task DeleteAccountAsync(DeleteAccountCommand command, CancellationToken cancellationToken);
}