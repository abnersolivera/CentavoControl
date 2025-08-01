namespace CentavoControl.Application.Validators.Category.Commands;

public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
{
    public AddCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Name cannot be null")
            .NotEmpty()
            .WithMessage("Name cannot be empty")
            .MaximumLength(100)
            .WithMessage("Name cannot be longer than 100 characters");

        RuleFor(x => x.Type)
            .NotNull()
            .WithMessage("Type cannot be null")
            .NotEmpty()
            .WithMessage("Type cannot be empty")
            .Must(type => Enum.TryParse<ETransactionType>(type, out _))
            .WithMessage("Type must be a valid transaction type");

    }
}