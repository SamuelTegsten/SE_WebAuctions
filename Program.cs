using Microsoft.EntityFrameworkCore;
using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Service;
using WebAuctions.Persistence.Context;
using WebAuctions.Persistence.SqlPersistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectDbConnection")));

builder.Services.AddScoped<IAuctionPersistence, AuctionSqlPersistence>();
builder.Services.AddScoped<IUserPersistence, UserSqlPersistence>();
builder.Services.AddScoped<IItemPersistence, ItemSqlPersistence>();

builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IUserService, UserService>();

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

app.Run();
