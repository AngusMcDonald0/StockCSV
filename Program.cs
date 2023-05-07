using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockCSV.Data;
using StockCSV.Interfaces;
using StockCSV.Services;

// db context dependancy injection 
//var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
//var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};UserID=sa;Password={dbPassword}";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StockCSVContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockCSVContext") ?? throw new InvalidOperationException("Connection string 'StockCSVContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IFileUploadService, FileUploadLocalService>();

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
