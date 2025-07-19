namespace CentavoControl.Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Category>> GetByUserIdAsync(string userId, CancellationToken cancellationToken);
    Task<IEnumerable<Category>> GetByTypeAndUserIdAsync(ETransactionType type, string userId, CancellationToken cancellationToken);
    Task AddAsync(Category category, CancellationToken cancellationToken);
    Task UpdateAsync(Category category, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}