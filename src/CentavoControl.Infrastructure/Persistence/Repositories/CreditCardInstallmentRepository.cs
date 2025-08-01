namespace CentavoControl.Infrastructure.Persistence.Repositories;

public class CreditCardInstallmentRepository(DataContext context) : ICreditCardInstallmentRepository
{
    public async Task<CreditCardInstallment?> GetByIdAsync(Guid id)
    {
        return await context.Set<CreditCardInstallment>().FindAsync(id);
    }

    public async Task<IEnumerable<CreditCardInstallment>> GetByExpenseIdAsync(Guid creditCardExpenseId)
    {
        return await context.Set<CreditCardInstallment>()
            .Where(i => i.CreditCardExpenseId == creditCardExpenseId)
            .ToListAsync();
    }

    public async Task AddAsync(CreditCardInstallment installment)
    {
        await context.Set<CreditCardInstallment>().AddAsync(installment);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CreditCardInstallment installment)
    {
        context.Set<CreditCardInstallment>().Update(installment);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var installment = await GetByIdAsync(id);
        if (installment != null)
        {
            context.Set<CreditCardInstallment>().Remove(installment);
            await context.SaveChangesAsync();
        }
    }
}

