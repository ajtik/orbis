using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Models.Repositories;

namespace MovieApp.Controllers;

public class MovieController : Controller
{
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;

    public MovieController(
        IMovieRepository movieRepository,
        IGenreRepository genreRepository
        )
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
    }

    public IActionResult Index()
    {
        ViewData["Movies"] = _movieRepository.FindAll();
        return View();
    }

    public IActionResult Add()
    {
        ViewData["Genres"] = _genreRepository.FindAll();

        return View("Views/Movie/MovieForm.cshtml");
    }

    public IActionResult AddMovie()
    {
        var name = (string)Request.Form["name"];
        var description = (string)Request.Form["description"];
        var genreId = Convert.ToInt32(Request.Form["category"]);
        var genre = _genreRepository.FindById(genreId);
        var file = Request.Form.Files[0];
        var uploadPath = Path.GetRelativePath(".", "wwwroot/upload/" + file.FileName);

        using (var stream = System.IO.File.Create(uploadPath))
        {
            file.CopyTo(stream);
        }

        _movieRepository.AddMovie(name, file.FileName, description, genre);
        return new RedirectToRouteResult(new { controller = "Movie", action = "Index"});
    }

    public IActionResult Delete(int id)
    {

        return new RedirectToRouteResult(new { controller = "Movie", action = "Index" });
    }
}
