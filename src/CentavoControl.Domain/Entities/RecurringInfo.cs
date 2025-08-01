namespace CentavoControl.Domain.Entities;

public class RecurringInfo
{
    protected RecurringInfo()
    {
        
    }
    
    public RecurringInfo(Guid payableId, ERecurrenceType recurrenceType, Guid recurrenceGroupId, Payable payable)
    {
        PayableId = payableId;
        RecurrenceType = recurrenceType;
        RecurrenceGroupId = recurrenceGroupId;
        Payable = payable;
    }
    public Guid PayableId { get; private set; }
    public ERecurrenceType RecurrenceType { get; private set; }
    public Guid RecurrenceGroupId { get; private set; }
    public Payable Payable { get; private set; }
}