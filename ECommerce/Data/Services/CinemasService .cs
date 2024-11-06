using ECommerce.Data.Base;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services;

public class CinemasService :EntityBaseRepository<Cinema>, ICinemasService//bu class dbcontext e bağımlı
{
    readonly AppDbContext _service;
    public CinemasService(AppDbContext service): base(service)
    {

    }
}







