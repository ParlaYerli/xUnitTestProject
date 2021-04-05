using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        Product GetById(int productId);
        List<Product> GetListProduct();
        void AddProduct(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
