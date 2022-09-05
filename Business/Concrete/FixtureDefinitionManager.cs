using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class FixtureDefinitionManager : IFixtureDefinitionService
    {
        private IFixtureDefinitionDal _fixtureDefinitionDal;
        public FixtureDefinitionManager(IFixtureDefinitionDal fixtureDefinitionDal)
        {
            _fixtureDefinitionDal = fixtureDefinitionDal;
        }

        [RoleOperation("FixtureDefinition.Insert")]
        [ValidationAspect(typeof(FixtureDefinitionValidator))]
        public IResult Add(FixtureDefinition fixtureDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfFixtureDefinitionNameExists(fixtureDefinition.Id, fixtureDefinition.Name));
            if (result != null)
                return result;

            _fixtureDefinitionDal.Add(fixtureDefinition);
            return new SuccessResult(Messages.Added);
        }

        [RoleOperation("FixtureDefinition.Delete")]
        public IResult Delete(FixtureDefinition fixtureDefinition)
        {
            _fixtureDefinitionDal.Delete(fixtureDefinition);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<FixtureDefinition> GetById(int fixtureDefinitionId)
        {
            return new SuccessDataResult<FixtureDefinition>(_fixtureDefinitionDal.Get(p => p.Id == fixtureDefinitionId));
        }

        public IDataResult<List<FixtureDefinition>> GetList()
        {
            return new SuccessDataResult<List<FixtureDefinition>>(_fixtureDefinitionDal.GetList().ToList());
        }

        [RoleOperation("FixtureDefinition.Update")]
        [ValidationAspect(typeof(FixtureDefinitionValidator))]
        public IResult Update(FixtureDefinition fixtureDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfFixtureDefinitionNameExists(fixtureDefinition.Id, fixtureDefinition.Name));
            if (result != null)
                return result;

            _fixtureDefinitionDal.Update(fixtureDefinition);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfFixtureDefinitionNameExists(int Id, string fixtureDefinitionName)
        {
            var result = _fixtureDefinitionDal.GetList(x => x.Id != Id && x.Name == fixtureDefinitionName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
