
using ECommerce.Data;
using ECommerce.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers;

public class MoviesController : Controller
{
    readonly IMoviesService  _service;

    public MoviesController(IMoviesService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allMovies = await _service.GetAllAsync(m=> m.Cinema);
            
         return View(allMovies);
    }
    public async Task<IActionResult> Details(int id)
    {
        var movieDetails=await _service.GetMoviesByIdAsync(id);
        return View(movieDetails);
    }
}
