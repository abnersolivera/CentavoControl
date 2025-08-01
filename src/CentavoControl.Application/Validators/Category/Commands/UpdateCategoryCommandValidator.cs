namespace CentavoControl.Application.Validators.Category.Commands;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator(ICategoryRepository repository)
    {
        RuleFor(x => x)
            .MustAsync(async (command, cancellation) =>
            {
                var category = await repository.GetByIdAsync(command.GetCategoryId(), cancellation);
                return category != null;
            })
            .WithMessage("Category not found.");

        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Name cannot be null.")
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");
        
        RuleFor(x => x.Type)
            .NotNull()
            .WithMessage("Type cannot be null.")
            .NotEmpty()
            .WithMessage("Type is required.")
            .Must(type => Enum.TryParse<ETransactionType>(type, out _))
            .WithMessage("Type must be a valid transaction type.");
    }
}