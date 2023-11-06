using Microsoft.EntityFrameworkCore;
using RealtimeNotificationsSignalR.Data;
using RealtimeNotificationsSignalR.Hubs;
using RealtimeNotificationsSignalR.MiddlewareExtensions;
using RealtimeNotificationsSignalR.SubscribeTableDependencies;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSignalR();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ), 
    ServiceLifetime.Singleton
    );

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

// DI
builder.Services.AddSingleton<DashboardHub>();
builder.Services.AddSingleton<SubscribeProductTableDependency>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapHub<DashboardHub>("/dashboardHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.UseSqlTableDependency<SubscribeProductTableDependency>(builder.Configuration.GetConnectionString("DefaultConnection"));

app.Run();