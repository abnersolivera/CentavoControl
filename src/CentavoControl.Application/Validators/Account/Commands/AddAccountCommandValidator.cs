namespace CentavoControl.Application.Validators.Account.Commands;

/// <summary>
/// Validator for the AddAccountCommand.
/// </summary>
public class AddAccountCommandValidator : AbstractValidator<AddAccountCommand>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public AddAccountCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Name cannot be null.")
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");
        
        RuleFor(x => x.InitialBalance)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Balance must be a non-negative number.");
    }
}