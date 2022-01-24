using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class SessionManager : ISessionService
    {
        private ISessionDal _SessionDal;

        public SessionManager(ISessionDal SessionDal)
        {
            _SessionDal = SessionDal;
        }

        public IDataResult<Session> GetById(int SessionId)
        {
            return new SuccessDataResult<Session>(_SessionDal.Get(p => p.Id == SessionId));
        }

        public IDataResult<List<Session>> GetList()
        {
            return new SuccessDataResult<List<Session>>(_SessionDal.GetList().ToList());
        }

        public IResult Add(Session Session)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(Session.Id, Session.Name));
            if (result != null)
                return result;

            IResult result2 = BusinessRules.Run(CheckIfSessionYearSequenceExists(Session.Id, Session.Year, Session.Sequence));
            if (result2 != null)
                return result2;

            _SessionDal.Add(Session);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Session Session)
        {
            _SessionDal.Delete(Session);
            return new SuccessResult(Messages.Deleted);

        }

        public IResult Update(Session Session)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(Session.Id, Session.Name));
            if (result != null)
                return result;

            IResult result2 = BusinessRules.Run(CheckIfSessionYearSequenceExists(Session.Id, Session.Year, Session.Sequence));
            if (result2 != null)
                return result2;

            _SessionDal.Update(Session);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfSessionNameExists(int Id,string SessionName)
        {
            var result = _SessionDal.GetList(x => x.Id != Id && x.Name == SessionName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfSessionYearSequenceExists(int Id, int Year, int Sequence)
        {
            var result = _SessionDal.GetList(x => x.Id != Id && x.Year == Year && x.Sequence == Sequence).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
