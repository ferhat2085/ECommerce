﻿
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Base;

public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext _context;

    public EntityBaseRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(T entity)
    {
        _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        //var entity = await _context.Set<T>().FirstOrDefaultAsync(m=> m.Id == id);
        var entity = await GetByIdAsync(id);
        EntityEntry entityEntry = _context.Entry<T>(entity);
        entityEntry.State = EntityState.Deleted;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        EntityEntry entityEntry = _context.Entry<T>(entity);
        entityEntry.State = EntityState.Modified;
    }
}

