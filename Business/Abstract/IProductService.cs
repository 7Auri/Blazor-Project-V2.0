using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IProductService : IEntityService<Product>
    {
        IDataResult<List<ProductDetails>> GetProductDetails(int productId);
        IDataResult<List<Product>> GetProductAll();
    }
}
