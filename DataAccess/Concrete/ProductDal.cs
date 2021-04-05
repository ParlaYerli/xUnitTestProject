using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class ProductDal : IProductDal
    {
        public void AddProduct(Product product)
        {
            using (var context= new AppContextDB())
            {
                context.Set<Product>().Add(product);
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (var context = new AppContextDB())
            {
                context.Set<Product>().Remove(product);
                context.SaveChanges();
            }
        }

        public Product GetById(int productId)
        {
            using (var context = new AppContextDB())
            {
                var product= context.Set<Product>().Find(productId);
                return product;
            }
        }

        public List<Product> GetListProduct()
        {
            using (var context = new AppContextDB())
            {
                List<Product> list = context.Set<Product>().ToList();
                return list;
            }
        }

        public void Update(Product product)
        {
            using (var context = new AppContextDB())
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
