using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        public Task Add(Product product);
        public Task Delete(Product product);
        public Task Update(Product product);
        public Task<Product> GetById(int productId);
        public Task<IEnumerable<Product>> GetList();
    }
}
