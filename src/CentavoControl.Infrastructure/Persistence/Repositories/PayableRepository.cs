namespace CentavoControl.Infrastructure.Persistence.Repositories;

public class PayableRepository(DataContext context) : IPayableRepository
{
    public async Task<Payable?> GetByIdAsync(Guid id)
    {
        return await context.Set<Payable>().FindAsync(id);
    }

    public async Task<IEnumerable<Payable>> GetByUserIdAsync(string userId)
    {
        return await context.Set<Payable>()
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Payable>> GetByAccountIdAsync(Guid accountId)
    {
        return await context.Set<Payable>()
            .Where(p => p.AccountId == accountId)
            .ToListAsync();
    }

    public async Task AddAsync(Payable payable)
    {
        await context.Set<Payable>().AddAsync(payable);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Payable payable)
    {
        context.Set<Payable>().Update(payable);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var payable = await GetByIdAsync(id);
        if (payable != null)
        {
            context.Set<Payable>().Remove(payable);
            await context.SaveChangesAsync();
        }
    }
}

