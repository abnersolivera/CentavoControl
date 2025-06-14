namespace CentavoControl.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Set<Category>().FindAsync(id);
    }

    public async Task<IEnumerable<Category>> GetByUserIdAsync(string userId)
    {
        return await _context.Set<Category>()
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(Category category)
    {
        await _context.Set<Category>().AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Set<Category>().Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await GetByIdAsync(id);
        if (category != null)
        {
            _context.Set<Category>().Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}

