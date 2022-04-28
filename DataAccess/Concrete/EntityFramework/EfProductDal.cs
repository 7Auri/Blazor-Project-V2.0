using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfProductDal : EfEntityRepositoryBase<Product, BPDbContext>, IProductDal
    {
        public List<ProductDetails> GetProductDetails(Expression<Func<ProductDetails, bool>> filter)
        {
            using (BPDbContext context = new ())
            {
                var result = from product in context.Products
                             join c in context.Colors
                             on product.ColorId equals c.Id
                             join b in context.Brands
                             on product.BrandId equals b.Id
                             join cat in context.Categories
                             on product.CategoryId equals cat.Id
                             join img in context.ProductImages
                             on product.ProductImage.Id equals img.Id
                             join sta in context.States
                             on product.StateId equals sta.Id
                             select new ProductDetails
                             {
                                 ProductId=product.Id,
                                 ProductName = product.Name,
                                 Status=sta.Status,
                                 BuyPrice=product.BuyPrice,
                                 IsOfferable=product.IsOfferable,
                                 IsSold=product.IsSold,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 CategoryName=cat.Name,
                                 ImagePath=img.ImagePath

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
        public List<Product> GetProductAll(Expression<Func<Product, bool>> filter = null)
        {
            using (BPDbContext context = new())
            {
                var result = from product in context.Products
                             join c in context.Colors
                             on product.ColorId equals c.Id
                             join b in context.Brands
                             on product.BrandId equals b.Id
                             join cat in context.Categories
                             on product.CategoryId equals cat.Id
                             join img in context.ProductImages
                             on product.ProductImage.Id equals img.Id
                             join sta in context.States
                             on product.StateId equals sta.Id
                             select new Product
                             {
                                 Id = product.Id,
                                 Name = product.Name,
                                 State = product.State,
                                 BuyPrice = product.BuyPrice,
                                 IsOfferable = product.IsOfferable,
                                 IsSold = product.IsSold,
                                 Brand = product.Brand,
                                 Color = product.Color,
                                 Category = product.Category,
                                ProductImage = product.ProductImage

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
