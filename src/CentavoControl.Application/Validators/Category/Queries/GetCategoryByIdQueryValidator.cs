using CentavoControl.Application.Queries.Category;

namespace CentavoControl.Application.Validators.Category.Queries;

public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator(ICategoryRepository repository)
    {
        RuleFor(x => x.GetId())
            .MustAsync(async (id, cancellation) =>
            {
                var category = await repository.GetByIdAsync(id, cancellation);
                return category != null;
            })
            .WithMessage("Category not found.");
    }
}