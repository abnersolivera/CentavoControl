using CentavoControl.Application.Queries.Category;

namespace CentavoControl.Application.Validators.Category.Queries;

public class GetCategoryByTypeAndUserIdQueryValidator : AbstractValidator<GetCategoryByTypeAndUserIdQuery>
{
    public GetCategoryByTypeAndUserIdQueryValidator(ICategoryRepository repository)
    {
        
        RuleFor(x => x.GetType())
            .Must(type => Enum.TryParse<ETransactionType>(type, true, out _))
            .WithMessage("Type must be a valid transaction type.");
        
        RuleFor(x => x)
            .MustAsync(async (query, cancellation) =>
            {
                var typeParse = Enum.Parse<ETransactionType>(query.GetType(), true);
                var category = await repository.GetByTypeAndUserIdAsync(typeParse, query.GetUserId(), cancellation);
                return category.Any();
            })
            .WithMessage("Category not found.");
    }
}