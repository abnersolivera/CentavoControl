namespace CentavoControl.Application.Commands.Payable;

public class DeletePayableCommand(Guid id)
{
    public Guid Id { get; private set; } = id;
}