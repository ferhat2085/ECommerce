using ECommerce.Data.Base;
using ECommerce.Models;

namespace ECommerce.Data.Services;

//CRUD operation Create, Read Update Delete 
public interface IMoviesService:IEntityBaseRepository<Movie>
{
    Task<Movie> GetMoviesByIdAsync(int id);
  
}
