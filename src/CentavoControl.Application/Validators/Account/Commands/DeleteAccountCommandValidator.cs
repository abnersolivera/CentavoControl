namespace CentavoControl.Application.Validators.Account.Commands;

/// <summary>
/// Validator for the UpdateAccountCommand.
/// </summary>
public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public DeleteAccountCommandValidator(IAccountRepository repository)
    {
        RuleFor(x => x)
            .MustAsync(async (command, cancellation) =>
            {
                var account = await repository.GetByIdAsync(command.GetAccountId(), cancellation);
                return account != null;
            })
            .WithMessage("Account not found.");
    }
}