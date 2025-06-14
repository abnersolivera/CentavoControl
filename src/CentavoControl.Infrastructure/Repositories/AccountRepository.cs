namespace CentavoControl.Infrastructure.Repositories;

public class AccountRepository(DataContext context) : IAccountRepository
{
    public async Task<Account?> GetByIdAsync(Guid id)
    {
        return await context.Set<Account>().FindAsync(id);
    }

    public async Task<IEnumerable<Account>> GetByUserIdAsync(string userId)
    {
        return await context.Set<Account>()
            .Where(a => a.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(Account account)
    {
        await context.Set<Account>().AddAsync(account);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Account account)
    {
        context.Set<Account>().Update(account);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var account = await GetByIdAsync(id);
        if (account != null)
        {
            context.Set<Account>().Remove(account);
            await context.SaveChangesAsync();
        }
    }
}

