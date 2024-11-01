using ECommerce.Data.Base;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services;

public class ActorsService : IActorsService//bu class dbcontext e bağımlı
{
    readonly AppDbContext _context;
    public ActorsService(AppDbContext context)//dependency inversion
    {
        _context = context;
    }

    public async Task AddAsync(Actor actor)// Tamamen asenkron yapıya döndü..
    {
        _context.Actors.AddAsync(actor);
        await _context.SaveChangesAsync();

    }



    public async Task<IEnumerable<Actor>> GetAllAsync()
    {
        return await _context.Actors.ToListAsync();
    }

    public async Task<Actor> GetByIdAsync(int id)
    {
        Actor actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id); // Tamamen asenkron yapıya döndü..
        if (actor is not null)
        {
            return actor;
        }
        return new Actor();
    }

    public async Task<Actor> UpdateAsync(Actor newActor)
    {
        _context.Actors.Update(newActor);
        await _context.SaveChangesAsync();
        return newActor;
    }

    public async Task DeleteAsync(int id)
    {
        Actor actor =await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
        if (actor != null)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }
    }
}
