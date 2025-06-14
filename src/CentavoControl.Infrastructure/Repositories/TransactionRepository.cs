namespace CentavoControl.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly DataContext _context;

    public TransactionRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        return await _context.Set<Transaction>().FindAsync(id);
    }

    public async Task<IEnumerable<Transaction>> GetByUserIdAsync(string userId)
    {
        return await _context.Set<Transaction>()
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId)
    {
        return await _context.Set<Transaction>()
            .Where(t => t.AccountId == accountId)
            .ToListAsync();
    }

    public async Task AddAsync(Transaction transaction)
    {
        await _context.Set<Transaction>().AddAsync(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        _context.Set<Transaction>().Update(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var transaction = await GetByIdAsync(id);
        if (transaction != null)
        {
            _context.Set<Transaction>().Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}

