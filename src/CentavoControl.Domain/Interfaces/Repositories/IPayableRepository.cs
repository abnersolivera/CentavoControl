namespace CentavoControl.Domain.Interfaces.Repositories;

public interface IPayableRepository
{
    Task<Payable?> GetByIdAsync(Guid id, CancellationToken cancellation);

    Task<IEnumerable<Payable>> GetByFiltersAsync(Guid? id, Guid? accountId, Guid? categoryId, string? userId,
        bool isPaid, int page, int rows, CancellationToken cancellation);

    Task<IEnumerable<Payable>> GetByUserIdAsync(string userId, CancellationToken cancellation);
    Task<IEnumerable<Payable>> GetByAccountIdAsync(Guid accountId, string userId, CancellationToken cancellation);
    Task<IEnumerable<Payable>> GetByCategoryIdAsync(Guid categoryId, string userId, CancellationToken cancellation);
    Task AddAsync(Payable payable, CancellationToken cancellation);
    Task UpdateAsync(Payable payable, CancellationToken cancellation);
    Task DeleteAsync(Guid id, CancellationToken cancellation);
}