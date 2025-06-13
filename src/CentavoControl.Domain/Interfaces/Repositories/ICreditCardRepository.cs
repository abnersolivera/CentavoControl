using CentavoControl.Domain.Entities;

namespace CentavoControl.Domain.Interfaces.Repositories;

public interface ICreditCardRepository
{
    Task<CreditCard?> GetByIdAsync(Guid id);
    Task<IEnumerable<CreditCard>> GetByUserIdAsync(string userId);
    Task AddAsync(CreditCard creditCard);
    Task UpdateAsync(CreditCard creditCard);
    Task DeleteAsync(Guid id);
}