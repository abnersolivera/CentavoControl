using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Queries.Category;

public class CategoryQueryHandler(ICategoryRepository repository) : ICategoryQuery
{
    public async Task<CategoryViewModel?> GetCategoryByIdAsync(GetCategoryByIdQuery query,
        CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(query.GetId(), cancellationToken);
        if (category == null) return null;
        var categoryViewModel = new CategoryViewModel(
            category.Id,
            category.Name,
            category.Type,
            category.UserId
        );

        return categoryViewModel;
    }

    public async Task<IEnumerable<CategoryViewModel?>> GetCategoriesByUserIdAsync(GetCategoryByUserIdQuery query,
        CancellationToken cancellationToken)
    {
        var categories = await repository.GetByUserIdAsync(query.GetUserId(), cancellationToken);
        var categoryViewModels = categories.Select(category => new CategoryViewModel(
            category.Id,
            category.Name,
            category.Type,
            category.UserId
        ));
        return categoryViewModels;
    }
}