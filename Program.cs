using Microsoft.EntityFrameworkCore;
using SistemaCardapioFinal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*builder.Services.AddDbContext<Contexto> //Anap
    (options => options.UseSqlServer("Data Source=SP-1491024\\SQLSENAI;Initial Catalog = SistemaCardapioFinal;Integrated Security = True;TrustServerCertificate = True"));*/

builder.Services.AddDbContext<Contexto> //Ana Alturria
    (options => options.UseSqlServer("Data Source=SP-1491037\\SQLSENAI;Initial Catalog =  SistemaCardapioFinal;Integrated Security = True;TrustServerCertificate = True"));

/*builder.Services.AddDbContext<Contexto> //Ana alonso
    (options => options.UseSqlServer("Data Source=SP-1491013\\SQLSENAI;Initial Catalog =  SistemaCardapioFinal;Integrated Security = True;TrustServerCertificate = True"));/

/*builder.Services.AddDbContext<Contexto> //Ana carol
    (options => options.UseSqlServer("Data Source=SP-1491019\\SQLSENAI;Initial Catalog =  SistemaCardapioFinal;Integrated Security = True;TrustServerCertificate = True"));*/

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
