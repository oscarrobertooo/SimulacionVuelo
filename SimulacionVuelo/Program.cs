using Microsoft.EntityFrameworkCore;
using SimulacionVuelo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



string conexion = ConfigurationExtensions.GetConnectionString(builder.Configuration, "Conexion");
Console.Write(conexion);
builder.Services.AddDbContext<SistemaAviacionContext>(options => options.UseSqlServer(conexion));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//--------------Validar Conexion---------------------\\
using (var scope = app.Services.CreateScope())
{

    var serv = scope.ServiceProvider;
    try
    {
        var context = serv.GetRequiredService<SistemaAviacionContext>();
        context.Database.EnsureCreated();
    }
    catch (System.Exception)
    {
        throw;
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

