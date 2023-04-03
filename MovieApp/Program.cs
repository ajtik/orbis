using Microsoft.EntityFrameworkCore;
using MovieApp.Models.Repositories;
using Context = MovieApp.Context;

// inicializační soubor Program.cs
// používá top level statements, tudíž není potřeba metoda Main() jako dříve
// obsah zde je tělo metody Main()

// návrhový vzor builder pro sestavení aplikace
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context.AppContext>(options =>
{
    // Configuration.GetConnectionString si natáhne hodnotu z appsettings.json, případně podle módu(produkční, vývoj, ...)
    // vezme ze souboru appsettings.{APP_ENV}.json - appsettings.Development.json
    // mód je možno nastavit environmentální proměnnou DOTNET_ENVIRONMENT nebo ASPNETCORE_ENVIRONMENT
    options.UseSqlite(builder.Configuration.GetConnectionString("AppContext"));
});

// registrace služby do DI kontejneru
// služba se zaregistruje pod určitým typem rozhraní
// další třídy si mohou vyžádat služby z DI kontejneru pomocí rozhraní a nemusí se starat, jaká je konkrétní implementace
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// umožňuje přístup do složky wwwroot z prohlížeče
app.UseStaticFiles();
// umožňuje routování - mapování URL adres na jednotlivé kontrollery / akce
app.UseRouting();

//app.UseAuthorization();

// ruční mapování routy
// konkrétnější routy musí být zaregistrovány před těmi obecnějšími, aby je router zachytil správně
app.MapControllerRoute(
    name: "movie_list",
    pattern: "seznam-filmu",
    defaults: new { controller = "Movie", action = "Index" }
    );

// obecná routa, která zachytí veškeré požadavky a bude routovat ve formátu /{Controller}/{Akce} - /Movie/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// spustí nekonečnou smyčku naší aplikace
app.Run();
