using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddLocalization();
var idiomasSoportados = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("es-ES"),
    new CultureInfo("fr-FR"),
};
var localizationOpciones = new RequestLocalizationOptions();
localizationOpciones.SupportedCultures = idiomasSoportados;
localizationOpciones.SupportedUICultures = idiomasSoportados;
localizationOpciones.SetDefaultCulture("es-ES");
localizationOpciones.ApplyCurrentCultureToResponseHeaders = true;



builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRequestLocalization(localizationOpciones);

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
