namespace CentavoControl.Domain.Entities;

public class RecurringInfo
{
    protected RecurringInfo()
    {
        
    }
    
    public RecurringInfo(Guid payableId, string recurrenceType, Guid recurrenceGroupId, Payable payable)
    {
        PayableId = payableId;
        RecurrenceType = recurrenceType;
        RecurrenceGroupId = recurrenceGroupId;
        Payable = payable;
    }
    public Guid PayableId { get; private set; }
    public string RecurrenceType { get; private set; }
    public Guid RecurrenceGroupId { get; private set; }
    public Payable Payable { get; set; }
}