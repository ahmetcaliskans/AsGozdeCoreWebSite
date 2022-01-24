using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        string securityKey = "AsGozdeSurucuKursu2021ac*";
        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByUserName(userForLoginDto.UserName);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (userForLoginDto.Password != SecuredOperation.DeEncryptAES(userToCheck.Data.PasswordHash,securityKey))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            if (!userToCheck.Data.Active)
            {
                return new ErrorDataResult<User>(Messages.UserNotActive);
            }


            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            string passwordHash = SecuredOperation.EncryptAES(password, securityKey);
            var user = new User
            {
                UserName= userForRegisterDto.UserName,
                PasswordHash = passwordHash,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,                               
                Active = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExist(string userName)
        {
            if (_userService.GetByUserName(userName) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
