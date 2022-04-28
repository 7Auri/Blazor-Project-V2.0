using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
   public class ProductDetails : IDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int BuyPrice { get; set; }
        public bool IsOfferable { get; set; } = false;
        public bool IsSold { get; set; } = false;
        public string Status { get; set; }
    }
}
