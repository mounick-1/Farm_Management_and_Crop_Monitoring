using FarmManagement_and_CropMonitoring.Data;
using Microsoft.EntityFrameworkCore;
using FarmManagement_and_CropMonitoring.Services.Interfaces;
using FarmManagement_and_CropMonitoring.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICropService, CropService>();
builder.Services.AddScoped<IFieldService, FieldService>();
builder.Services.AddScoped<IResourceService, ResourceService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

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
