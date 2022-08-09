using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFixtureDefinitionService
    {
        IDataResult<FixtureDefinition> GetById(int fixtureDefinitionId);
        IDataResult<List<FixtureDefinition>> GetList();
        IResult Add(FixtureDefinition fixtureDefinition);
        IResult Update(FixtureDefinition fixtureDefinition);
        IResult Delete(FixtureDefinition fixtureDefinition);
    }
}
