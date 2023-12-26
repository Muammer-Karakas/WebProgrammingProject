using Microsoft.EntityFrameworkCore;
using WebProje.Models;
using WebProje.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HastaneRandevuDbContext>(options=>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//klinikTuruRepository nesnesi =>Dependency Injection
builder.Services.AddScoped<IKlinikTuruRepository, KlinikTuruRepository>();

//DoktorlarTablosuRepository nesnesi =>Dependency Injection
builder.Services.AddScoped<IDoktorlarTablosuRepository, DoktorlarTablosuRepository>();
//RandevuRepository nesnesi =>Dependency Injection
builder.Services.AddScoped<IRandevuRepository, RandevuRepository>();



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
