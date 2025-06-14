namespace CentavoControl.Infrastructure.Repositories;

public class CreditCardExpenseRepository : ICreditCardExpenseRepository
{
    private readonly DataContext _context;

    public CreditCardExpenseRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<CreditCardExpense?> GetByIdAsync(Guid id)
    {
        return await _context.Set<CreditCardExpense>().FindAsync(id);
    }

    public async Task<IEnumerable<CreditCardExpense>> GetByUserIdAsync(string userId)
    {
        return await _context.Set<CreditCardExpense>()
            .Where(e => e.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(CreditCardExpense expense)
    {
        await _context.Set<CreditCardExpense>().AddAsync(expense);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CreditCardExpense expense)
    {
        _context.Set<CreditCardExpense>().Update(expense);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var expense = await GetByIdAsync(id);
        if (expense != null)
        {
            _context.Set<CreditCardExpense>().Remove(expense);
            await _context.SaveChangesAsync();
        }
    }
}

