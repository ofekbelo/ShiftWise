namespace ShiftWise.Api.Domain.Entities;

public class Schedule
{
    public Guid Id { get; set; }
    public DateOnly WeekStart { get; set; } // לפי Week Type
    public string WeekType { get; set; } = "Default";
    public string Status { get; set; } = "Draft"; // Draft/Published
}
