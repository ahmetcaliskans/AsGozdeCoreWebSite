using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPersonnelDefinitionService
    {
        IDataResult<PersonnelDefinition> GetById(int personnelDefinitionId);
        IDataResult<PersonnelDefinition> GetByIdWithDetails(int personnelDefinitionId);
        IDataResult<List<PersonnelDefinition>> GetListByOfficeId(int officeId);
        IDataResult<List<PersonnelDefinition>> GetListWithDetails(int officeId);
        IResult Add(PersonnelDefinition personnelDefinition);
        IResult Update(PersonnelDefinition personnelDefinition);
        IResult Delete(PersonnelDefinition personnelDefinition);
    }
}
