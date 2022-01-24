using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
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

        public IResult Add(User User)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(User.UserId, User.UserName));
            if (result != null)
                return result;

            _userDal.Add(User);
            return new SuccessResult("Başarı ile Eklendi !");
        }

        public IResult Update(User User)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(User.UserId, User.UserName));
            if (result != null)
                return result;

            _userDal.Update(User);
            return new SuccessResult("Başarı ile Güncellendi !");
        }

        public IResult Delete(User User)
        {
            _userDal.Delete(User);
            return new SuccessResult("Başarı ile Silindi !");
        }

        private IResult CheckIfSessionNameExists(int Id, string UserName)
        {
            var result = _userDal.GetList(x => x.UserId != Id && x.UserName == UserName).Any();
            if (result)
            {
                return new ErrorResult("Bu Kullanıcı Adı Zaten Mevcut !");
            }

            return new SuccessResult();
        }

    }
}
