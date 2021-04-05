using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        public void Add(Product product);
        public void Delete(Product product);
        public void Update(Product product);
        public Product GetById(int productId);
        public List<Product> GetList();
    }
}
