namespace CentavoControl.Application.Queries.Account;

public class GetAccountByIdQuery
{
    private Guid _id;
    
    public void SetId(string id) => _id = Guid.Parse(id);
    
    public Guid GetId() => _id;
}