using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class CollectionDefinitionListViewComponent : ViewComponent
    {
        private ICollectionDefinitionService _collectionDefinitionService;

        public CollectionDefinitionListViewComponent(ICollectionDefinitionService collectionDefinitionService)
        {
            _collectionDefinitionService = collectionDefinitionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int collectionDefinitionId)
        {
            var result = _collectionDefinitionService.GetList();
            dynamic mymodel = new System.Dynamic.ExpandoObject();
            mymodel.CollectionDefinition = result.Data.OrderBy(x => x.Name).ThenBy(x=>x.Sequence).ToList();
            mymodel.SelectedId = collectionDefinitionId == null ? 0 : collectionDefinitionId;

            return View("CollectionDefinitionList", mymodel);
        }
    }
}
