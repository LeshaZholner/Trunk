using Trunk.Web.Data;
using Microsoft.EntityFrameworkCore;
using Trunk.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Vite.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TrunkDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TrunkContext")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<TrunkDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddViteServices(options =>
{
    options.Server.AutoRun = true;
    options.Server.Https = true;
    options.Server.PackageDirectory = "Assets";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

if (app.Environment.IsDevelopment())
{
    app.UseWebSockets();
    app.UseViteDevelopmentServer(true);
}

app.Run();
