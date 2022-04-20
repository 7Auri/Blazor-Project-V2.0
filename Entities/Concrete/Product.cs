﻿using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Product : BaseEntity
    {
     
        public int BuyPrice { get; set; }
        public bool IsOfferable { get; set; } = false;
        public bool IsSold { get; set; } = false;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
      
    }
}
