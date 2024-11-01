﻿using Desafio_FSBR.Data.Context;
using Desafio_FSBR.Data.Interfaces;
using Desafio_FSBR.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Desafio_FSBR.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();

    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> VerifyExist(int id)
    {
        return await _dbSet.AnyAsync(x => x.Id == id);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            entity.DelecaoLogica = true;
            await UpdateAsync(entity);
        }
    }

    public async Task<(IEnumerable<T> Items, int TotalCount)> GetAllAsync(int page, int pageSize)
    {
        var filteredItems = _dbSet.Where(x => x.DelecaoLogica == false);

        var items =  await filteredItems
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalCount = await filteredItems.CountAsync();

        return (items, totalCount);
    }

    public async Task<T> GetByIdAsync(int id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.DelecaoLogica);

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}