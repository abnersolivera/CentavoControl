namespace CentavoControl.Application.Validators.Category.Commands;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator(ICategoryRepository repository)
    {
        RuleFor(x => x.GetCategoryId())
            .MustAsync(async (categoryId, cancellation) =>
            {
                var category = await repository.GetByIdAsync(categoryId, cancellation);
                return category != null;
            })
            .WithMessage("Category not found.");
    }
}