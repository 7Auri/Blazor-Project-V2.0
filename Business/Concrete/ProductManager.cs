using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.SuccessListed);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.Id == id), Messages.SuccessListed);
        }

        public IDataResult<List<Product>> GetProductAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.SuccessListed);
        }

        public IDataResult<List<ProductDetails>> GetProductDetails(int productId )
        {
            return new SuccessDataResult<List<ProductDetails>>(_productDal.GetProductDetails(x=>x.ProductId==productId), Messages.SuccessListed);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
