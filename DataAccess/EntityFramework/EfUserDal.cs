using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework.Context;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, AsGozdeWebSiteDB>, IUserDal
    {
        /// <summary>
        /// aşağıdaki gibi tmp mantığı left join imkanı sağlıyor
        /// Kullanıcı tanımlarının office ismi ve role ismi bilgilerinin tablo da id olarak değilde isim olarak gösterilmesi için yapıldı.
        /// </summary>
        /// <returns></returns>
        public List<UserForRegisterDto> GetListWithDetails()
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {                
                var result = from u in context.Users
                             join o in context.Offices
                             on u.OfficeId equals o.Id into tmp
                             from o in tmp.DefaultIfEmpty()
                             join r in context.RoleTypes
                             on u.RoleTypeId equals r.Id into tmp2 
                             from r in tmp2.DefaultIfEmpty()
                             select new UserForRegisterDto
                             {
                                 UserId = u.UserId,
                                 UserName = u.UserName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Active = u.Active,
                                 OfficeId = u.OfficeId,
                                 OfficeName = o.Name,
                                 RoleId = u.RoleTypeId,
                                 RoleName = r.Name,
                                 Title = u.Title
                             };
                return result.ToList();
            }
        }
    }
}
