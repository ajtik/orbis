using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Models.Repositories;

namespace MovieApp.Controllers;

// Kontroller pro práci s filmy
// Rolí kontrolleru je vzít data z modelu a předat je do pohledu, viz. MVC pattern
public class MovieController : Controller
{
    // privátní property pro práci s repozitáři
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;

    // kontroller i repozitáře jsou zaregistrováni v DI kontejneru(viz. Program.cs), tudíž si je můžeme vyžádat pomocí rozhraní
    // nezajímá nás, jaká je konkrétní implementace toho rozhraní
    // cheme tady jen nějakou službu, která nám poskytuje metody v daném rozhraní a to jak funguje na pozadí je nám fuk
    public MovieController(
        IMovieRepository movieRepository,
        IGenreRepository genreRepository
        )
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
    }

    // Metoda pro seznam filmů
    public IActionResult Index()
    {
        // vyhledání filmů v databázi a předání do pohledu
        ViewData["Movies"] = _movieRepository.FindAll();
        
        // pokud neuvedeme explicitně název pohledu, bude se hledat v Views/{Controller}/{Action}.cshtml
        // tedy Views/Movie/Index.cshmtl
        return View();
    }

    // Metoda pro přidání filmu
    // nikoliv zpracování formuláře, nýbrž pouze pro zobrazení stránky s vytvářecím formulářem
    public IActionResult Add()
    {
        // ve vytvářecím formuláři chceme mít předvyplněné dostupné žánry, tudíž si je tam předáme
        ViewData["Genres"] = _genreRepository.FindAll();

        return View("Views/Movie/MovieForm.cshtml");
    }

    // Metoda pro editaci filmu, má jako argument id filmu, který cheme editovat
    public IActionResult Edit(int id)
    {
        // vyhledáme si opět žánry do formuláře
        ViewData["Genres"] = _genreRepository.FindAll();
        // potřebujeme předvyplnit data do formuláře, tudíž si jej potřebujeme vyhledat
        // správně bychom měli i ošetřit, jestli vůbec film s daným ID funguje
        ViewData["Movie"] = _movieRepository.FindById(id);

        return View("Views/Movie/MovieForm.cshtml");
    }

    // Metoda pro zpracování formuláře pro přidání filmu
    public IActionResult AddMovie()
    {
        // získání dat z formuláře
        // správně by měla proběhnout ještě validace
        var name = (string)Request.Form["name"];
        var description = (string)Request.Form["description"];
        var genreId = Convert.ToInt32(Request.Form["category"]);
        var genre = _genreRepository.FindById(genreId);
        var file = Request.Form.Files[0];
        // cesta kam budeme ukládat nahraný soubor
        // dáváme do složky wwwroot/ která je přístupná "z venku" a dostaneme se k obrázku i z prohlížeče
        var uploadPath = Path.GetRelativePath(".", "wwwroot/upload/" + file.FileName);

        // using automaticky zavolá dispose a uvolní prostředky - netřeba se tím nyní zabývat
        using (var stream = System.IO.File.Create(uploadPath))
        {
            // zkopírování dočasného souboru na námi určené místo
            file.CopyTo(stream);
        }

        // přes repozitář přidáme nový film
        _movieRepository.AddMovie(name, file.FileName, description, genre);
        
        // nyní nevracíme pohled(ViewResult), nicméně Result, který provede přesměrování na daný controller a routu
        return new RedirectToRouteResult(new { controller = "Movie", action = "Index"});
    }

    // metoda pro editaci filmu 
    public IActionResult EditMovie(int id)
    {
        var name = (string)Request.Form["name"];
        var description = (string)Request.Form["description"];
        var genreId = Convert.ToInt32(Request.Form["category"]);
        var genre = _genreRepository.FindById(genreId);
        var movie = _movieRepository.FindById(id);

        if (movie == null)
        {
            return new RedirectToRouteResult(new { controller = "Movie", action = "Index" });
        }

        movie.Name = name;
        movie.Description = description;
        movie.Genre = genre;

        _movieRepository.UpdateMovie(movie);
        return new RedirectToRouteResult(new { controller = "Movie", action = "Index" });
    }

    // metoda pro smazání filmu
    public IActionResult Delete(int id)
    {
        var movie = _movieRepository.FindById(id);

        if (movie != null) {
            _movieRepository.DeleteMovie(movie);
        }

        return new RedirectToRouteResult(new { controller = "Movie", action = "Index" });
    }
}
