namespace CentavoControl.Application.Commands.Payable;

public class AddPayableCommand(
    string description,
    decimal amount,
    DateTime dueDate,
    Guid accountId,
    Guid categoryId)
{
    public string Description { get; private set; } = description;
    public decimal Amount { get; private set; } = amount;
    public DateTime DueDate { get; private set; } = dueDate;
    public Guid AccountId { get; private set; } = accountId;
    public Guid CategoryId { get; private set; } = categoryId;
    
    public Domain.Entities.Payable ToEntity(string userId)
    {
        return new Domain.Entities.Payable(Guid.NewGuid(), 
            Description,
            Amount,
            DueDate,
            AccountId,
            CategoryId,
            userId);
    }
}