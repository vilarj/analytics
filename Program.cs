using analytics.Context;
using analytics.Interfaces;
using analytics.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AnalyticsContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("ConnString")));
builder.Services.AddCors();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

app.Run();
