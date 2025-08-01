namespace CentavoControl.Infrastructure.Persistence.Repositories;

public class CreditCardRepository(DataContext context) : ICreditCardRepository
{
    public async Task<CreditCard?> GetByIdAsync(Guid id)
    {
        return await context.Set<CreditCard>().FindAsync(id);
    }

    public async Task<IEnumerable<CreditCard>> GetByUserIdAsync(string userId)
    {
        return await context.Set<CreditCard>()
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(CreditCard creditCard)
    {
        await context.Set<CreditCard>().AddAsync(creditCard);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CreditCard creditCard)
    {
        context.Set<CreditCard>().Update(creditCard);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var creditCard = await GetByIdAsync(id);
        if (creditCard != null)
        {
            context.Set<CreditCard>().Remove(creditCard);
            await context.SaveChangesAsync();
        }
    }
}

