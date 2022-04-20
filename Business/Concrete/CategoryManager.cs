using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        public IResult Add(Category category)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(Category category)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Category>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Category> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
