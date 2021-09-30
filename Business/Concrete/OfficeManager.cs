using Business.Abstract;
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
    public class OfficeManager : IOfficeService
    {
        private IOfficeDal _officeDal;

        public OfficeManager(IOfficeDal officeDal)
        {
            _officeDal = officeDal;
        }

        public IDataResult<Office> GetById(int officeId)
        {
            return new SuccessDataResult<Office>(_officeDal.Get(p => p.OfficeId == officeId));
        }

        public IDataResult<List<Office>> GetList()
        {
            return new SuccessDataResult<List<Office>>(_officeDal.GetList().ToList());
        }

        public IResult Add(Office office)
        {
            IResult result = BusinessRules.Run(CheckIfOfficeNameExists(office.Name));
            if (result!=null)
            {
                return result;
            }

            _officeDal.Add(office);
            return new SuccessResult("Başarı ile Eklendi !");
        }

        public IResult Delete(Office office)
        {
            _officeDal.Delete(office);
            return new SuccessResult("Başarı ile Silindi.");
        }        

        public IResult Update(Office office)
        {
            _officeDal.Update(office);
            return new SuccessResult("Başarı ile Güncellendi");
        }

        private IResult CheckIfOfficeNameExists(string officeName)
        {
            var result = _officeDal.GetList(x => x.Name == officeName).Any();
            if (result)
            {
                return new ErrorResult("Bu Şube Zaten Mevcut !");
            }

            return new SuccessResult();
        }
    }
}
