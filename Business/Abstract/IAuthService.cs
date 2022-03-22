using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> ChangePass(User user, string newPassword);
        IResult UserExist(string userCode);
        //IDataResult<AccessToken> CreateAccessToken(User user);
        //IDataResult<AccessToken> CreateRefreshToken();
    }
}
