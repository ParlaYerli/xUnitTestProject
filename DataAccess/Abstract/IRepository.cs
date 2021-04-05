using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity:class , new()
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Create(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
    }
}
