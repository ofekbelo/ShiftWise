namespace ShiftWise.Api.Domain.Entities;

public class Assignment
{
    public Guid Id { get; set; }
    public Guid ScheduleId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateOnly Day { get; set; }
    public Guid ShiftDefinitionId { get; set; }
}
