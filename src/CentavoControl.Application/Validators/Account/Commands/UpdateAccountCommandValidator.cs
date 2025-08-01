namespace CentavoControl.Application.Validators.Account.Commands;

/// <summary>
/// Validator for the UpdateAccountCommand.
/// </summary>
public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public UpdateAccountCommandValidator(IAccountRepository repository)
    {
        RuleFor(x => x)
            .MustAsync(async (command, cancellation) =>
            {
                var account = await repository.GetByIdAsync(command.GetAccountId(), cancellation);
                return account != null;
            })
            .WithMessage("Account not found.");

        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Name cannot be null.")
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");
    }
}