using Microsoft.EntityFrameworkCore;
using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Service;
using WebAuctions.Persistence.Context;
using WebAuctions.Persistence.SqlPersistence;
using Microsoft.AspNetCore.Identity;
using WebAuctions.Data;
using WebAuctions.Areas.Identity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var databaseProvider = builder.Configuration.GetSection("DatabaseConfiguration")["Provider"];

if (databaseProvider == "SqlServer")
{
    builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectDbConnection")));

    builder.Services.AddDbContext<ProjectDbIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectDbIdentityContextConnection")));
}
else if (databaseProvider == "Sqlite")
{
    builder.Services.AddDbContext<ProjectDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ProjectDbConnection")));
    builder.Services.AddDbContext<ProjectDbIdentityContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ProjectDbIdentityContextConnection")));
}

builder.Services.AddDefaultIdentity<WebAuctionsUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<ProjectDbIdentityContext>();

builder.Services.AddScoped<IAuctionPersistence, AuctionSqlPersistence>();
builder.Services.AddScoped<IBidPersistence, BidSqlPersistence>();
builder.Services.AddScoped<IItemPersistence, ItemSqlPersistence>();

builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddScoped<UserManager<WebAuctionsUser>>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Member" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

using(var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<WebAuctionsUser>>();

    string email = "admin@admin.com";
    string pass = "Admin1234!";

    if(await userManager.FindByEmailAsync(email) == null)
    {
        var user = new WebAuctionsUser();
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;
        await userManager.CreateAsync(user, pass);

        await userManager.AddToRoleAsync(user, "Admin");
    }

}
app.MapRazorPages();

app.Run();
