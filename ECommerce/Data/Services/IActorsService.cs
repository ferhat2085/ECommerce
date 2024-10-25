using ECommerce.Models;

namespace ECommerce.Data.Services;

//CRUD operation Create, Read Update Delete 
public interface IActorsService
{
    Task<IEnumerable<Actor>> GetAllAsync();

    Task<Actor> GetByIdAsync(int id);

    Task AddAsync(Actor actor);

    Task<Actor> UpdateAsync(Actor newActor);

    void Delete(int id);
}
