using CentavoControl.Application.ViewModels;
using CentavoControl.Domain.Enums;

namespace CentavoControl.Application.Queries.Category;

public class CategoryQueryHandler(ICategoryRepository repository) : ICategoryQueryHandler
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

    public async Task<IEnumerable<CategoryViewModel>> GetCategoriesByTypeAndUserIdAsync(GetCategoryByTypeAndUserIdQuery query, CancellationToken cancellationToken)
    {
        var transactionTypeParse = Enum.Parse<ETransactionType>(query.GetType(), true);
        
        var categories = await repository.GetByTypeAndUserIdAsync(transactionTypeParse, query.GetUserId(), cancellationToken);
        
        var categoryViewModels = categories.Select(category => new CategoryViewModel(
            category.Id,
            category.Name,
            category.Type,
            category.UserId
        ));
        
        return categoryViewModels;
    }
}