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
    public class ReportLayoutManager : IReportLayoutService
    {
        private IReportLayoutDal _reportLayoutDal;
        public ReportLayoutManager(IReportLayoutDal reportLayoutDal)
        {
            _reportLayoutDal = reportLayoutDal;
        }
        public IResult Add(ReportLayout reportLayout)
        {
            IResult result = BusinessRules.Run(CheckIfReportLayoutNameExists(reportLayout.ReportId, reportLayout.DisplayName));
            if (result != null)
                return result;

            _reportLayoutDal.Add(reportLayout);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(ReportLayout reportLayout)
        {
            _reportLayoutDal.Delete(reportLayout);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<ReportLayout> GetByDisplayName(string displayName)
        {
            return new SuccessDataResult<ReportLayout>(_reportLayoutDal.Get(p => p.DisplayName == displayName));
        }

        public IDataResult<ReportLayout> GetById(int reportId)
        {
            return new SuccessDataResult<ReportLayout>(_reportLayoutDal.Get(p => p.ReportId == reportId));
        }

        public IDataResult<List<ReportLayout>> GetList()
        {   

            return new SuccessDataResult<List<ReportLayout>>(_reportLayoutDal.GetList().ToList());
        }

        public IResult Update(ReportLayout reportLayout)
        {
            IResult result = BusinessRules.Run(CheckIfReportLayoutNameExists(reportLayout.ReportId, reportLayout.DisplayName));
            if (result != null)
                return result;

            _reportLayoutDal.Update(reportLayout);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfReportLayoutNameExists(int reportId, string displayName)
        {
            var result = _reportLayoutDal.GetList(x => x.ReportId != reportId && x.DisplayName == displayName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
