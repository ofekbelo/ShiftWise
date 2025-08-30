namespace ShiftWise.Api.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Email { get; set; } = default!;
    // תפקיד לפי RBAC
    public string Role { get; set; } = "Employee"; // Owner/Manager/Scheduler/Employee
    // אילוצים ברמת עובד – קישור לטבלה נפרדת בגרסאות מתקדמות
}
