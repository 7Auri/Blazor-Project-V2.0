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
        IProductImageDal _productImageDal;
        IFileHelper _fileHelper;
        public ProductImageManager(IProductImageDal productImageDal, IFileHelper fileHelper)
        {
            _productImageDal = productImageDal;
            _fileHelper = fileHelper;
        }


        public IResult Add(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckIfProductImageLimit(productImage.ProductId));
            if (result != null)
            {
                return result;
            }
            productImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.SuccessImageUpload);
        }

        public IResult Delete(ProductImage productImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductImage>> GetByProductId(int productId)
        {
            var result = BusinessRules.Run(CheckProductImage(productId));
            if (result != null)
            {
                return new ErrorDataResult<List<ProductImage>>(GetDefaultImage(productId).Data);
            }
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(c => c.ProductId == productId));
        }

        public IDataResult<ProductImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            productImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + productImage.ImagePath, PathConstants.ImagesPath);
            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.SuccessUpdate);
        }
        private IResult CheckIfProductImageLimit(int productId)
        {
            var result = _productImageDal.GetAll(c => c.ProductId == productId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<ProductImage>> GetDefaultImage(int productId)
        {

            List<ProductImage> productImage = new List<ProductImage>();
            productImage.Add(new ProductImage { ProductId = productId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<ProductImage>>(productImage);
        }
        private IResult CheckProductImage(int productId)
        {
            var result = _productImageDal.GetAll(c => c.ProductId == productId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
