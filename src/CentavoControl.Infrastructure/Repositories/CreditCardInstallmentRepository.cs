namespace CentavoControl.Infrastructure.Repositories;

public class CreditCardInstallmentRepository : ICreditCardInstallmentRepository
{
    private readonly DataContext _context;

    public CreditCardInstallmentRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<CreditCardInstallment?> GetByIdAsync(Guid id)
    {
        return await _context.Set<CreditCardInstallment>().FindAsync(id);
    }

    public async Task<IEnumerable<CreditCardInstallment>> GetByExpenseIdAsync(Guid creditCardExpenseId)
    {
        return await _context.Set<CreditCardInstallment>()
            .Where(i => i.CreditCardExpenseId == creditCardExpenseId)
            .ToListAsync();
    }

    public async Task AddAsync(CreditCardInstallment installment)
    {
        await _context.Set<CreditCardInstallment>().AddAsync(installment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CreditCardInstallment installment)
    {
        _context.Set<CreditCardInstallment>().Update(installment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var installment = await GetByIdAsync(id);
        if (installment != null)
        {
            _context.Set<CreditCardInstallment>().Remove(installment);
            await _context.SaveChangesAsync();
        }
    }
}

