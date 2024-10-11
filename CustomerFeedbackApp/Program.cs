using CustomerFeedbackApp.Data;
using CustomerFeedbackApp.Services.Http;
using CustomerFeedbackApp.Services.IRepositories;
using CustomerFeedbackApp.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog configuration
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJiraClient, JiraClient>();

builder.Services.AddControllersWithViews();

// Register db context
builder.Services.AddDbContext<CustomerFeedbackContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Content-Security-Policy", "default-src 'self';");
    await next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
