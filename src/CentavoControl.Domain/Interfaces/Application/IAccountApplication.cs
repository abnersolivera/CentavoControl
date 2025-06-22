namespace CentavoControl.Domain.Interfaces.Application;

public interface IAccountApplication
{
    Task<AccountDto?> GetAccountByIdAsync(GetAccountByIdCommand id);
    Task<IEnumerable<AccountDto>> GetAccountsByUserIdAsync(GetAccountsByUserIdCommand userId);
    Task<AccountDto> AddAccountAsync(AddAccountCommand account);
    Task<AccountDto> UpdateAccountAsync(UpdateAccountCommand account);
    Task DeleteAccountAsync(DeleteAccountCommand id);
}