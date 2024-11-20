using ECommerce.Data.Base;
using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce.Data.Services;

public interface IMoviesService : IEntityBaseRepository<Movie>


{
    Task<Movie> GetMovieByIdAsync(int id);

    Task<MovieDropdowns> GetMovieDropdownsValuesAsync();

    Task AddMovieAsync(MovieVM movie);
    Task UpdateMovieAsync(MovieVM movie);
}