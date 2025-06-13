using CentavoControl.Domain.Entities;

namespace CentavoControl.Domain.Interfaces.Repositories;

public interface ICreditCardInstallmentRepository
{
    Task<CreditCardInstallment?> GetByIdAsync(Guid id);
    Task<IEnumerable<CreditCardInstallment>> GetByExpenseIdAsync(Guid creditCardExpenseId);
    Task AddAsync(CreditCardInstallment installment);
    Task UpdateAsync(CreditCardInstallment installment);
    Task DeleteAsync(Guid id);
}