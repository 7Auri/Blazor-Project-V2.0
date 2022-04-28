using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OfferManager : IOfferService
    {
        IOfferDal _offerDal;

        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }

        public IResult Add(Offer offer)
        {
            _offerDal.Add(offer);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IResult Delete(Offer offer)
        {
            _offerDal.Delete(offer);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<Offer>> GetAll()
        {
            return new SuccessDataResult<List<Offer>>(_offerDal.GetAll(), Messages.SuccessListed);
        }

        public IDataResult<Offer> GetById(int id)
        {
            return new SuccessDataResult<Offer>(_offerDal.Get(x => x.Id == id), Messages.SuccessListed);
        }

        public IResult Update(Offer offer)
        {
            _offerDal.Update(offer);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
