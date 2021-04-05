using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.AddProduct(product);
        }
        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
        public Product GetById(int productId)
        {
            return _productDal.GetById(productId);
        }
        public List<Product> GetList()
        {
            return _productDal.GetListProduct();
        }
        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
