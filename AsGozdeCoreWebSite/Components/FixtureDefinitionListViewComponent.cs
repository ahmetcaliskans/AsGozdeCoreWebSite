using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class FixtureDefinitionListViewComponent : ViewComponent
    {
        private IFixtureDefinitionService _fixtureDefinitionService;

        public FixtureDefinitionListViewComponent(IFixtureDefinitionService fixtureDefinitionService)
        {
            _fixtureDefinitionService = fixtureDefinitionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int fixtureDefinitionId)
        {
            var result = _fixtureDefinitionService.GetList();
            dynamic mymodel = new System.Dynamic.ExpandoObject();
            mymodel.FixtureDefinition = result.Data.OrderBy(x => x.Name).ToList();
            mymodel.SelectedId = fixtureDefinitionId == null ? 0 : fixtureDefinitionId;

            return View("FixtureDefinitionList", mymodel);
        }
    }
}
