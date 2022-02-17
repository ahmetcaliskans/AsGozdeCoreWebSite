using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        private IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public IResult Add(Branch branch)
        {
            IResult result = BusinessRules.Run(CheckIfbranchNameExists(branch.Id, branch.Name));
            if (result != null)
                return result;

            _branchDal.Add(branch);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Branch branch)
        {
            _branchDal.Delete(branch);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Branch> GetById(int branchId)
        {
            return new SuccessDataResult<Branch>(_branchDal.Get(p => p.Id == branchId));
        }

        public IDataResult<List<Branch>> GetList()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetList().ToList());
        }

        public IResult Update(Branch branch)
        {
            IResult result = BusinessRules.Run(CheckIfbranchNameExists(branch.Id, branch.Name));
            if (result != null)
                return result;

            _branchDal.Update(branch);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfbranchNameExists(int Id, string branchName)
        {
            var result = _branchDal.GetList(x => x.Id != Id && x.Name == branchName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
