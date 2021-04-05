using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task Add(Product product)
        {
            await _productDal.Create(product);
        }
        public async Task Delete(Product product)
        {
            await _productDal.Delete(product);
        }
        public async Task<Product> GetById(int productId)
        {
            return await _productDal.GetById(productId);
        }
        public async Task<IEnumerable<Product>> GetList()
        {
            return await _productDal.GetAll();
        }
        public async Task Update(Product product)
        {
            await _productDal.Update(product);
        }
    }
}
