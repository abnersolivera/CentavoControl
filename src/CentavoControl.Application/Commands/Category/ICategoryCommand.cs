using CentavoControl.Application.ViewModels;

namespace CentavoControl.Application.Commands.Category;

public interface ICategoryCommand
{
    Task<CategoryViewModel> AddCategoryAsync(AddCategoryCommand command, CancellationToken cancellationToken);
    Task<CategoryViewModel> UpdateCategoryAsync(UpdateCategoryCommand command, CancellationToken cancellationToken);
    Task DeleteCategoryAsync(DeleteCategoryCommand command, CancellationToken cancellationToken);
}