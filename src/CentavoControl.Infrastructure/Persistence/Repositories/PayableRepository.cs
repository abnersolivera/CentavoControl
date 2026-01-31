namespace CentavoControl.Infrastructure.Persistence.Repositories;

public class PayableRepository(DataContext context) : IPayableRepository
{
    public async Task<Payable?> GetByIdAsync(Guid id, CancellationToken cancellation)
    {
        return await context.Payables.FindAsync([id, cancellation], cancellation);
    }

    public async Task<IEnumerable<Payable>> GetByFiltersAsync(Guid? id, Guid? accountId, Guid? categoryId,
        string? userId,
        bool isPaid, int page, int rows,
        CancellationToken cancellation)
    {
        var query = context.Payables.AsQueryable();

        if (id.HasValue)
        {
            query = query.Where(p => p.Id == id.Value);
        }

        if (accountId.HasValue)
        {
            query = query.Where(p => p.AccountId == accountId.Value);
        }

        if (categoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == categoryId.Value);
        }

        if (!string.IsNullOrEmpty(userId))
        {
            query = query.Where(p => p.UserId == userId);
        }

        query = query.Where(p => p.IsPaid == isPaid);

        return await query
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToListAsync(cancellation);
    }

    public async Task<IEnumerable<Payable>> GetByUserIdAsync(string userId, CancellationToken cancellation)
    {
        return await context.Payables
            .Where(p => p.UserId == userId)
            .ToListAsync(cancellation);
    }

    public async Task<IEnumerable<Payable>> GetByAccountIdAsync(Guid accountId, string userId,
        CancellationToken cancellation)
    {
        return await context.Payables
            .Where(p => p.AccountId == accountId && p.UserId == userId)
            .ToListAsync(cancellation);
    }

    public async Task<IEnumerable<Payable>> GetByCategoryIdAsync(Guid categoryId, string userId,
        CancellationToken cancellation)
    {
        return await context.Payables
            .Where(p => p.CategoryId == categoryId && p.UserId == userId)
            .ToListAsync(cancellation);
    }

    public async Task AddAsync(Payable payable, CancellationToken cancellation)
    {
        await context.Payables.AddAsync(payable, cancellation);
        await context.SaveChangesAsync(cancellation);
    }

    public async Task UpdateAsync(Payable payable, CancellationToken cancellation)
    {
        context.Payables.Update(payable);
        await context.SaveChangesAsync(cancellation);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellation)
    {
        var payable = await GetByIdAsync(id, cancellation);
        if (payable != null)
        {
            context.Payables.Remove(payable);
            await context.SaveChangesAsync(cancellation);
        }
    }
}