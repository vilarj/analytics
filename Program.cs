using analytics.Context;
using analytics.Interfaces;
using analytics.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var logFileName = $"Logs/{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.log";

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(logFileName)
    .CreateLogger();

builder.Services.AddControllers();
builder.Services.AddDbContext<AnalyticsContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("ConnString")));
builder.Services.AddCors();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

var app = builder.Build();

app.UseRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
app.Run();
