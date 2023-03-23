using Microsoft.EntityFrameworkCore;
using Context = MovieApp.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context.AppContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("AppContext"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// localhost/seznam-filmu

app.MapControllerRoute(
    name: "movie_list",
    pattern: "seznam-filmu",
    defaults: new { controller = "Movie", action = "List"}
    );

app.Run();
