using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public async Task Create(TEntity entity)
        {
            using (var _context = new TContext())
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (var _context = new TContext())
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            using (var _context = new TContext())
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            using (var _context = new TContext())
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task Update(TEntity entity)
        {
            using (var _context = new TContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
