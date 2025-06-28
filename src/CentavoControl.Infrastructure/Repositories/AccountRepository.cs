namespace CentavoControl.Infrastructure.Repositories;

public class AccountRepository(DataContext context) : IAccountRepository
{
    public async Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Account>().FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Account>> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await context.Set<Account>()
            .Where(a => a.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Account account, CancellationToken cancellationToken)
    {
        await context.Set<Account>().AddAsync(account, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Account account, CancellationToken cancellationToken)
    {
        context.Set<Account>().Update(account);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Account account, CancellationToken cancellationToken)
    {
        context.Set<Account>().Remove(account);
        await context.SaveChangesAsync(cancellationToken);
    }
}