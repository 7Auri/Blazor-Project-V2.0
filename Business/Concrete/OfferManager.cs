using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OfferManager : IOfferService
    {
        public IResult Add(Offer offer)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(Offer offer)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Offer>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Offer> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(Offer offer)
        {
            throw new System.NotImplementedException();
        }
    }
}
