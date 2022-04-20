using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Offer : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OfferedPrice { get; set; }
        public OfferStatus OfferStatus { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime Date { get; set; } = DateTime.Now;

    }
}
