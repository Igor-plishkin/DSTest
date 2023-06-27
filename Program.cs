using DSTest.Models;
using DSTest.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

builder.Services.AddTransient<FileService>();
builder.Services.AddTransient<MeasureService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
