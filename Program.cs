var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Serve static files
app.UseStaticFiles();

// Map controllers
app.MapControllers();

app.Run();
