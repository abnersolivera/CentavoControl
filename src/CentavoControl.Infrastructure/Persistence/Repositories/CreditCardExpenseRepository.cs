namespace CentavoControl.Infrastructure.Persistence.Repositories;

public class CreditCardExpenseRepository(DataContext context) : ICreditCardExpenseRepository
{
    public async Task<CreditCardExpense?> GetByIdAsync(Guid id)
    {
        return await context.Set<CreditCardExpense>().FindAsync(id);
    }

    public async Task<IEnumerable<CreditCardExpense>> GetByUserIdAsync(string userId)
    {
        return await context.Set<CreditCardExpense>()
            .Where(e => e.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(CreditCardExpense expense)
    {
        await context.Set<CreditCardExpense>().AddAsync(expense);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CreditCardExpense expense)
    {
        context.Set<CreditCardExpense>().Update(expense);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var expense = await GetByIdAsync(id);
        if (expense != null)
        {
            context.Set<CreditCardExpense>().Remove(expense);
            await context.SaveChangesAsync();
        }
    }
}

