using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Test.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Data.Context;
using Test.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

#region Configuracion de la base de datos SQLite
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlite("Data Source=MyDB.sqlite"));
builder.Services.AddScoped<IMyDbContext, MyDbContext>();
#endregion

#region Servicios
builder.Services.AddScoped<IFacturaServices,FacturaServices>();
builder.Services.AddScoped<IPagoServices, PagoServices>();
builder.Services.AddScoped<IProductoServices,ProductoServices>();
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
#endregion

#region Authentication
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
//builder.Services.AddSingleton<UserAccountService>();
builder.Services.AddScoped<IUserAccountService,UserAccountService>();
#endregion

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    try
    {
        if (db.Database.EnsureCreated())
        {
            // La base de datos se ha creado (o ya existe)
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al crear la base de datos: {ex.Message}");
        // Puedes agregar más manejo de errores según tus necesidades
    }
}

app.Run();
