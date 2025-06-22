namespace CentavoControl.Domain.Interfaces.Application;

public interface IAccountApplication
{
    Task<AccountDto?> GetAccountByIdAsync(GetAccountByIdCommand command);
    Task<IEnumerable<AccountDto>> GetAccountsByUserIdAsync(GetAccountsByUserIdCommand command);
    Task<AccountDto> AddAccountAsync(AddAccountCommand command);
    Task<AccountDto> UpdateAccountAsync(UpdateAccountCommand command);
    Task DeleteAccountAsync(DeleteAccountCommand command);
}