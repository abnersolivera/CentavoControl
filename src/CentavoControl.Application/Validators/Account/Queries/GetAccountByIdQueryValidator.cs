using CentavoControl.Application.Queries.Account;

namespace CentavoControl.Application.Validators.Account.Queries;

public class GetAccountByIdQueryValidator : AbstractValidator<GetAccountByIdQuery>
{
    public GetAccountByIdQueryValidator(IAccountRepository repository)
    {
        RuleFor(x => x.GetId())
            .MustAsync(async (id, cancellation) =>
            {
                var account = await repository.GetByIdAsync(id, cancellation);
                return account != null;
            })
            .WithMessage("Account not found.");
    }
}