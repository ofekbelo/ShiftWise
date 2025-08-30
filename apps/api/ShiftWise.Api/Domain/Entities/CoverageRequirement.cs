namespace ShiftWise.Api.Domain.Entities;

public class CoverageRequirement
{
    public Guid Id { get; set; }
    public DayOfWeek Day { get; set; }
    public Guid ShiftDefinitionId { get; set; }
    public int RequiredEmployees { get; set; }
}
