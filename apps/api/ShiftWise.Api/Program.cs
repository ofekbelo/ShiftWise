using Microsoft.EntityFrameworkCore;
using Prometheus;
using Serilog;
using ShiftWise.Api.Infrastructure;
using ShiftWise.Api.Domain.Entities;
using ShiftWise.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(p => p
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("http://localhost:5173")); // Vite dev server
});

builder.Services.AddSignalR();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseHttpMetrics(); // /metrics
app.MapMetrics();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapHub<Microsoft.AspNetCore.SignalR.Hub>("/hubs/schedule");

app.MapHub<ScheduleHub>("/hubs/schedule");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Employees.Any())
    {
        db.Employees.AddRange(
            new Employee { Id = Guid.NewGuid(), FullName = "Alice Cohen", Email = "alice@company.com", Phone = "050-0000000", Role = "Manager" },
            new Employee { Id = Guid.NewGuid(), FullName = "Ben Levi", Email = "ben@company.com", Phone = "050-1111111", Role = "Employee" }
        );
        await db.SaveChangesAsync();
    }
}

app.MapGet("/employees", async (AppDbContext db) =>
{
    var list = await db.Employees
        .Select(e => new { e.Id, e.FullName, e.Email, e.Phone, e.Role })
        .ToListAsync();
    return Results.Ok(list);
});


app.Run();
