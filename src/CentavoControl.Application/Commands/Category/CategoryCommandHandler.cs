using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Commands.Category;

public class CategoryCommandHandler(ICategoryRepository repository) : ICategoryCommandHandler
{
    public async Task<CategoryViewModel> AddCategoryAsync(AddCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = command.ToEntity("0741789C-C8B4-468F-BE98-CC7569D85918");
        await repository.AddAsync(category, cancellationToken);
        CategoryViewModel categoryViewModel = new(category.Id, category.Name, category.Type, category.UserId);
        return categoryViewModel;
    }

    public async Task<CategoryViewModel> UpdateCategoryAsync(UpdateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(command.GetCategoryId(), cancellationToken);
        category?.Update(command.Name, command.ParseType());
        await repository.UpdateAsync(category!, cancellationToken);
        CategoryViewModel updatedCategory = new(category!.Id, category.Name, category.Type, category.UserId);
        return updatedCategory; 
    }

    public async Task DeleteCategoryAsync(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(command.GetCategoryId(), cancellationToken);
        await repository.DeleteAsync(category.Id, cancellationToken);

    }
}