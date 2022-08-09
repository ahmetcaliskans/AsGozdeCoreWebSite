using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class PersonnelDefinitionListViewComponent : ViewComponent
    {
        private IPersonnelDefinitionService _personnelDefinitionService;

        public PersonnelDefinitionListViewComponent(IPersonnelDefinitionService personnelDefinitionService)
        {
            _personnelDefinitionService = personnelDefinitionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int personnelDefinitionId, int officeId)
        {
            var result = _personnelDefinitionService.GetListByOfficeId(officeId);
            dynamic mymodel = new System.Dynamic.ExpandoObject();
            mymodel.PersonnelDefinition = result.Data.OrderBy(x => x.Name).ToList();
            mymodel.SelectedId = personnelDefinitionId == null ? 0 : personnelDefinitionId;

            return View("PersonnelDefinitionList", mymodel);
        }
    }
}
