namespace CentavoControl.Domain.Interfaces.Repositories;

public interface IPayableRepository
{
    Task<Payable?> GetByIdAsync(Guid id);
    Task<IEnumerable<Payable>> GetByUserIdAsync(string userId);
    Task<IEnumerable<Payable>> GetByAccountIdAsync(Guid accountId);
    Task AddAsync(Payable payable);
    Task UpdateAsync(Payable payable);
    Task DeleteAsync(Guid id);
}