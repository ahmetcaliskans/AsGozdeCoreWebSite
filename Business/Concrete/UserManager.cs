using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> GetById(int UserId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserId == UserId));
        }

        public IDataResult<User> GetByUserName(string userName)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserName == userName));
        }

        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList().ToList());
        }

        public IDataResult<List<UserForRegisterDto>> GetListWithDetails()
        {
            return new SuccessDataResult<List<UserForRegisterDto>>(_userDal.GetListWithDetails().ToList());
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User User)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(User.UserId, User.UserName));
            if (result != null)
                return result;

            User.PasswordHash = SecuredOperation.EncryptAES("*", Messages.SecurityKey);

            _userDal.Add(User);
            return new SuccessResult(Messages.Added);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User User)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(User.UserId, User.UserName));
            if (result != null)
                return result;

            _userDal.Update(User);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(User User)
        {
            _userDal.Delete(User);
            return new SuccessResult(Messages.Deleted);
        }

        private IResult CheckIfSessionNameExists(int Id, string UserName)
        {
            var result = _userDal.GetList(x => x.UserId != Id && x.UserName == UserName).Any();
            if (result)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }

    }
}
