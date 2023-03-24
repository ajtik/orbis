using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Models.Repositories;

namespace MovieApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
