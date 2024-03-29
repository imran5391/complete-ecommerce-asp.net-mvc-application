﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context; //we need to inject the AppDbContext
        public EntityBaseRepository(AppDbContext context) //create constructor
        {
            _context = context;
        }

        //this part we are going to implement the generic versions
        //of the get all async and get by id asyn

        // Implementing Add method from actors service/ ActorsController
        //AddAsync() method in base repository 
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)  //DeleteAsync method in ActorsService, //DeleteAsync() in base repository
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperites)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperites.Aggregate(query, (current, includeProperites) => current.Include(includeProperites));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id); //Updating GetById method in ActorsService

        public async Task UpdateAsync(int id, T entity) //UpdateAsync() in base repository 
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }
    }
}
