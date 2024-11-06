using ECommerce.Data.Base;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services;

public class ActorsService :EntityBaseRepository<Actor>, IActorsService//bu class dbcontext e bağımlı
{
    readonly AppDbContext _context;
    public ActorsService(AppDbContext context): base(context)
    {

    }
}







