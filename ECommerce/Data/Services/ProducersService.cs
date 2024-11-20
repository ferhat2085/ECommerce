














































using ECommerce.Data.Base;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services;

public class ProducersService : EntityBaseRepository<Producer>, IProducersService//bu class dbcontext e bağımlı
{
    readonly AppDbContext _service;
    public ProducersService(AppDbContext service) : base(service)
    {

    }
}
