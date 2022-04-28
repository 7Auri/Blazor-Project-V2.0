using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetails> GetProductDetails(Expression<Func<ProductDetails, bool>> filter);
        List<Product> GetProductAll(Expression<Func<Product, bool>> filter = null);
        
    }
}
