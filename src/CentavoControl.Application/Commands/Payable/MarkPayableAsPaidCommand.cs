namespace CentavoControl.Application.Commands.Payable;

public class MarkPayableAsPaidCommand(Guid id)
{
    public Guid Id { get; private set; } = id;
}