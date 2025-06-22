namespace CentavoControl.Domain.Commands.Account;

public class GetAccountsByUserIdCommand
{
    private string _userId;
    
    public void SetUserId(string userId) => _userId = userId;
    
    public string GetUserId() => _userId;
}