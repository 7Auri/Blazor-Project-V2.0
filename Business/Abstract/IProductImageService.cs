using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;


namespace Business.Abstract
{
   public interface IProductImageService
    {
        IResult Add(int productId, IFormFile file);
        IResult Update(int id, IFormFile file);
        IResult Delete(int id);
        IDataResult<List<ProductImage>> GetAllByProductId(int productId);
        IDataResult<List<ProductImage>> GetAll();
    }
}
