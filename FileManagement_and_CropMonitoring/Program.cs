using FarmManagement_and_CropMonitoring.Data;
using FarmManagement_and_CropMonitoring.Models;
using FarmManagement_and_CropMonitoring.Services;
using FarmManagement_and_CropMonitoring.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Register Services (Dependency Injection)
builder.Services.AddScoped<ICropService, CropService>();
builder.Services.AddScoped<IFieldService, FieldService>();
builder.Services.AddScoped<IResourceService, ResourceService>();

// 2. Add Controllers and Views
builder.Services.AddControllersWithViews();

// 3. Register DbContext (SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4. ADD THIS: Configure Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    // Ensure the database is created
    context.Database.EnsureCreated();

    // Check if the Users table is empty
    if (!context.Users.Any())
    {
        context.Users.Add(new User
        {
            Username = "log_user",
            Password = "123", 
            Role = "Admin"
        });
        context.SaveChanges();
    }
}

// 5. Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 6. ORDER MATTERS: Use Authentication BEFORE Authorization
app.UseAuthentication();
app.UseAuthorization();

// 7. UPDATED: Set Default Route to Account/Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();