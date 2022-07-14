using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class CollectionDefinitionTypeListViewComponent : ViewComponent
    {
        private ICollectionDefinitionTypeService _collectionDefinitionTypeService;

        public CollectionDefinitionTypeListViewComponent(ICollectionDefinitionTypeService collectionDefinitionTypeService)
        {
            _collectionDefinitionTypeService = collectionDefinitionTypeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int collectionDefinitionTypeId)
        {
            var result = _collectionDefinitionTypeService.GetList();
            dynamic mymodel = new System.Dynamic.ExpandoObject();
            mymodel.CollectionDefinitionType = result.Data;
            mymodel.SelectedId = collectionDefinitionTypeId == null ? 99 : collectionDefinitionTypeId;
            //return await Task.FromResult((IViewComponentResult)View("GetCollectionDefinitionTypeList", result.Data));
            return View("CollectionDefinitionTypeList", mymodel);
        }
    }
}
