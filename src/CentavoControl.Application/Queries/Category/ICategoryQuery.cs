using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Queries.Category;

public interface ICategoryQuery
{
    Task<CategoryViewModel?> GetCategoryByIdAsync(GetCategoryByIdQuery query, CancellationToken cancellationToken);
    Task<IEnumerable<CategoryViewModel?>> GetCategoriesByUserIdAsync(GetCategoryByUserIdQuery query, CancellationToken cancellationToken);
}