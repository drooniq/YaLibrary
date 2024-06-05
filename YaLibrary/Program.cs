using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YaLibrary.Data;
using YaLibrary.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<YaLibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YaLibraryContext") ?? throw new InvalidOperationException("Connection string 'YaLibraryContext' not found.")));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<YaLibraryContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
