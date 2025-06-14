namespace CentavoControl.Infrastructure.Repositories;

public class CreditCardRepository : ICreditCardRepository
{
    private readonly DataContext _context;

    public CreditCardRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<CreditCard?> GetByIdAsync(Guid id)
    {
        return await _context.Set<CreditCard>().FindAsync(id);
    }

    public async Task<IEnumerable<CreditCard>> GetByUserIdAsync(string userId)
    {
        return await _context.Set<CreditCard>()
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(CreditCard creditCard)
    {
        await _context.Set<CreditCard>().AddAsync(creditCard);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CreditCard creditCard)
    {
        _context.Set<CreditCard>().Update(creditCard);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var creditCard = await GetByIdAsync(id);
        if (creditCard != null)
        {
            _context.Set<CreditCard>().Remove(creditCard);
            await _context.SaveChangesAsync();
        }
    }
}

