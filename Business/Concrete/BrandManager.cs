using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        public IResult Add(Brand brand)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(Brand brand)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Brand> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(Brand brand)
        {
            throw new System.NotImplementedException();
        }
    }
}
