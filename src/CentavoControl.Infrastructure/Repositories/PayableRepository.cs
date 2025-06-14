namespace CentavoControl.Infrastructure.Repositories;

public class PayableRepository : IPayableRepository
{
    private readonly DataContext _context;

    public PayableRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Payable?> GetByIdAsync(Guid id)
    {
        return await _context.Set<Payable>().FindAsync(id);
    }

    public async Task<IEnumerable<Payable>> GetByUserIdAsync(string userId)
    {
        return await _context.Set<Payable>()
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Payable>> GetByAccountIdAsync(Guid accountId)
    {
        return await _context.Set<Payable>()
            .Where(p => p.AccountId == accountId)
            .ToListAsync();
    }

    public async Task AddAsync(Payable payable)
    {
        await _context.Set<Payable>().AddAsync(payable);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Payable payable)
    {
        _context.Set<Payable>().Update(payable);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var payable = await GetByIdAsync(id);
        if (payable != null)
        {
            _context.Set<Payable>().Remove(payable);
            await _context.SaveChangesAsync();
        }
    }
}

