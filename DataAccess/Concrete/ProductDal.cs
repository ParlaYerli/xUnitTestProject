using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProductDal : RepositoryBase<Product,AppContextDB> , IProductDal
    {
       
    }
}
