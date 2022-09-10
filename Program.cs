using Microsoft.EntityFrameworkCore;
using ParavastuWeek5.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//get the path for the output directory.

var path = Directory.GetCurrentDirectory();

//get access to the connection strings -- appsettings.json file.
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

//Dependency Injection.
builder.Services.AddDbContext<NPGoldContext>(options => options.UseSqlServer(configuration.GetConnectionString("NPGoldConnString").Replace("|DataDirectory|", path)));

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
