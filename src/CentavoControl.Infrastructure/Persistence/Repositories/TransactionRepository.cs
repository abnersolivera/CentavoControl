namespace CentavoControl.Infrastructure.Persistence.Repositories;

public class TransactionRepository(DataContext context) : ITransactionRepository
{
    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        return await context.Set<Transaction>().FindAsync(id);
    }

    public async Task<IEnumerable<Transaction>> GetByUserIdAsync(string userId)
    {
        return await context.Set<Transaction>()
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId)
    {
        return await context.Set<Transaction>()
            .Where(t => t.AccountId == accountId)
            .ToListAsync();
    }

    public async Task AddAsync(Transaction transaction)
    {
        await context.Set<Transaction>().AddAsync(transaction);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        context.Set<Transaction>().Update(transaction);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var transaction = await GetByIdAsync(id);
        if (transaction != null)
        {
            context.Set<Transaction>().Remove(transaction);
            await context.SaveChangesAsync();
        }
    }
}

