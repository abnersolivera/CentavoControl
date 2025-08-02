namespace CentavoControl.Application.Commands.Payable;

public class UpdatePayableCommand(
    string description,
    decimal amount,
    DateTime dueDate,
    Guid accountId,
    Guid categoryId)
{
    private Guid _id;
    public string Description { get; private set; } = description;
    public decimal Amount { get; private set; } = amount;
    public DateTime DueDate { get; private set; } = dueDate;
    public Guid AccountId { get; private set; } = accountId;
    public Guid CategoryId { get; private set; } = categoryId;
    
    public void SetPayableId(string id) => _id = Guid.Parse(id);
    public Guid GetPayableId() => _id;
}