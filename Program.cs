using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem;
using WarehouseManagementSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbWarehouseContext>(builder =>
{
    builder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=DbWarehouse;Integrated Security=True");
});
builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 2;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<DbWarehouseContext>();

var app = builder.Build();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
