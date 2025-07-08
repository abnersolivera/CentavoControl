namespace CentavoControl.Application.Commands.Account;

public class DeleteAccountCommand
{
    private Guid _id;

    public void SetAccountId(string accountId) => _id = Guid.Parse(accountId);
    public Guid GetAccountId() => _id;
}