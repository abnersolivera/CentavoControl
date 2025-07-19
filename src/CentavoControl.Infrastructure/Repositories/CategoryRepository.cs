using CentavoControl.Domain.Enums;

namespace CentavoControl.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _context.Categories
            .Where(c => c.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetByTypeAndUserIdAsync(ETransactionType type, string userId, CancellationToken cancellationToken)
    {
        return await _context.Categories
            .Where(c => c.Type == type && c.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Category category, CancellationToken cancellationToken)
    {
        await _context.Categories.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Category category, CancellationToken cancellationToken)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await GetByIdAsync(id, cancellationToken);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

