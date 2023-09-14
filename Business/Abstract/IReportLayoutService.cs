using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReportLayoutService
    {
        IDataResult<ReportLayout> GetById(int reportId);
        IDataResult<ReportLayout> GetByDisplayName(string displayName);
        IDataResult<List<ReportLayout>> GetList();
        IResult Add(ReportLayout reportLayout);
        IResult Update(ReportLayout reportLayout);
        IResult Delete(ReportLayout reportLayout);
    }
}
