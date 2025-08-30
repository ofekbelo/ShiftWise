using Microsoft.EntityFrameworkCore;
using ShiftWise.Api.Domain.Entities;

namespace ShiftWise.Api.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<ShiftDefinition> ShiftDefinitions => Set<ShiftDefinition>();
    public DbSet<CoverageRequirement> CoverageRequirements => Set<CoverageRequirement>();
    public DbSet<Schedule> Schedules => Set<Schedule>();
    public DbSet<Assignment> Assignments => Set<Assignment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();
        base.OnModelCreating(modelBuilder);
    }
}
