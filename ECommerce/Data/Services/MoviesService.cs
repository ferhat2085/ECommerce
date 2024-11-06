using ECommerce.Data.Base;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services;

public class MoviesService :EntityBaseRepository<Movie>, IMoviesService//bu class dbcontext e bağımlı
{
    readonly AppDbContext _context;
    public MoviesService(AppDbContext context): base(context)
    {
        _context = context; 
    }

    public async Task<Movie> GetMoviesByIdAsync(int id)
    {
        var movieDetails = await _context.Movies
              .Include(x=> x.Producer)
              .Include(c => c.Cinema)
              .Include(m => m.Actors_Movies).ThenInclude(a => a.Actor)
              .FirstOrDefaultAsync(n => n.Id == id);
        return movieDetails;
    }
}







