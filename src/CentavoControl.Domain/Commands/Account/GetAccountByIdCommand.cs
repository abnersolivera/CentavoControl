namespace CentavoControl.Domain.Commands.Account;

public class GetAccountByIdCommand
{
    private Guid _id;
    
    public void SetId(string id) => _id = Guid.Parse(id);
    
    public Guid GetId() => _id;
}