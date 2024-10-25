
using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers;

public class MoviesController : Controller
{
    readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var allMovies = await _context.Movies
            .Include(m => m.Cinema)
            .OrderByDescending(m => m.StartDate)
            .ToListAsync(); //await ekle eklemezsen devamını okumadan gecer. dataya ihtiyacın oldugu zaman awaiti kullan.
        return View(allMovies);
    }
}
