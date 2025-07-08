namespace CentavoControl.Application.Queries.Account;

public class GetAccountsByUserIdQuery
{
    private string _userId = string.Empty;
    
    public void SetUserId(string userId) => _userId = userId;
    
    public string GetUserId() => _userId;
}