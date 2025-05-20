using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCProject.DAL;
using MVCProject.Models;
using MVCProject.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;

    options.User.RequireUniqueEmail = true;

    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<LayoutService>();

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
   pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
