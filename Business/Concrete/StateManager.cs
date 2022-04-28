using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StateManager : IStateService
    {
        IStateDal _stateDal;

        public StateManager(IStateDal stateDal)
        {
            _stateDal = stateDal;
        }

        public IResult Add(State state)
        {
            _stateDal.Add(state);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IResult Delete(State state)
        {
            _stateDal.Delete(state);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<State>> GetAll()
        {
            return new SuccessDataResult<List<State>>(_stateDal.GetAll(), Messages.SuccessListed);
        }

        public IDataResult<State> GetById(int id)
        {
            return new SuccessDataResult<State>(_stateDal.Get(x => x.Id == id), Messages.SuccessListed);
        }

        public IResult Update(State state)
        {
            _stateDal.Update(state);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
