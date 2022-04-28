using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        string _defaultImagePath = "images/default.png";

        IProductImageDal _productImageDal;
        IFileHelper _fileHelper;
        public ProductImageManager(IProductImageDal productImageDal, IFileHelper fileHelper)
        {
            _productImageDal = productImageDal;
            _fileHelper = fileHelper;
        }

        
        public IResult Add(int productId, IFormFile file)
        {
            var result = BusinessRules.Run(CheckIfTheImageLimitForThisProductHasBeenExceeded(productId));
            if (!result.Success) return result;

            var productImage = new ProductImage
            {
                ProductId = productId,
                Date = DateTime.Now,
                ImagePath = _fileHelper.Add(file)
            };

            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.SuccessAdd);
        }

        
        public IResult Delete(int id)
        {
            var productImage = _productImageDal.Get(ci => ci.Id == id);
            _fileHelper.Delete(productImage.ImagePath);

            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            var result = _productImageDal.GetAll();
            return new SuccessDataResult<List<ProductImage>>(result, Messages.SuccessListed);
        }

        public IDataResult<List<ProductImage>> GetAllByProductId(int productId)
        {
            var result = _productImageDal.GetAll(ci => ci.ProductId == productId);
            if (result.Count == 0) result.Add(new ProductImage { ImagePath = _defaultImagePath });
            return new SuccessDataResult<List<ProductImage>>(result, Messages.SuccessListed);
        }

        
        public IResult Update(int id, IFormFile file)
        {
            var productImage = _productImageDal.Get(ci => ci.Id == id);
            productImage.ImagePath = _fileHelper.Update(file, productImage.ImagePath);

            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.SuccessUpdate);
        }

        private IResult CheckIfTheImageLimitForThisProductHasBeenExceeded(int productId)
        {
            var result = _productImageDal.GetAll(ci => ci.ProductId == productId);
            if (result.Count >= 5) return new ErrorResult(Messages.ImageLimitForThisProductHasBeenExceeded);

            return new SuccessResult();
        }
    }
}

