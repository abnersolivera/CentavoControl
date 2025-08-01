using CentavoControl.Domain.Enums;

namespace CentavoControl.Infrastructure.Persistence.Repositories;

public class CategoryRepository(DataContext context) : ICategoryRepository
{
    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Categories.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await context.Categories
            .Where(c => c.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetByTypeAndUserIdAsync(ETransactionType type, string userId, CancellationToken cancellationToken)
    {
        return await context.Categories
            .Where(c => c.Type == type && c.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Category category, CancellationToken cancellationToken)
    {
        await context.Categories.AddAsync(category, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Category category, CancellationToken cancellationToken)
    {
        context.Categories.Update(category);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await GetByIdAsync(id, cancellationToken);
        if (category != null)
        {
            context.Categories.Remove(category);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}

