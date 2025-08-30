namespace ShiftWise.Api.Domain.Entities;

public class ShiftDefinition
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!; // לדוגמה: "Morning"
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }
    public bool IsActive { get; set; } = true;
    public int GranularityMinutes { get; set; } = 30; // ברירת מחדל MVP
}
