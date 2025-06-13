namespace CentavoControl.Domain.Interfaces.Repositories;

public interface ICreditCardExpenseRepository
{
    Task<CreditCardExpense?> GetByIdAsync(Guid id);
    Task<IEnumerable<CreditCardExpense>> GetByUserIdAsync(string userId);
    Task AddAsync(CreditCardExpense expense);
    Task UpdateAsync(CreditCardExpense expense);
    Task DeleteAsync(Guid id);
}