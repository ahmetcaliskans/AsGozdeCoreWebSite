using Business.BusinessAspects.Autofac;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Controllers
{
    public class ProjectDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Collection()
        {
            RoleOperation roleOperation = new RoleOperation("ProjectDashboard/Collection.Show");
            roleOperation.fn_checkRole();
            DashboardState dashboardState = new DashboardState();
            DashboardParameterState parameterState = new DashboardParameterState("OfficeId", Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value), typeof(Int32));

            //DashboardItemState gridFilterState = new DashboardItemState("gridDashboardItem1");
            //gridFilterState.MasterFilterValues.AddRange(new List<object[]>() {
            //    new string[1] { "Andrew Fuller" },
            //    new string[1] { "Laura Callahan" }
            //});

            //DashboardItemState treemapDrilldownState = new DashboardItemState("treemapDashboardItem1");
            //treemapDrilldownState.DrillDownValues.Add("Beverages");

            //DashboardItemState rangeFilterState = new DashboardItemState("rangeFilterDashboardItem1");
            //rangeFilterState.RangeFilterState.Selection =
            //    new RangeFilterSelection(new DateTime(2015, 1, 1), new DateTime(2016, 1, 1));

            dashboardState.Parameters.Add(parameterState);
            //dashboardState.Items.AddRange(new List<DashboardItemState>() {
            //    gridFilterState,
            //    treemapDrilldownState,
            //    rangeFilterState }
            //);

            DashboardControlModel dashboardControlModel = new DashboardControlModel { DashboardId = "1", WorkingMode = WorkingMode.ViewerOnly, DashboardState = dashboardState };
            return View("CollectionDashboard", dashboardControlModel);
        }

        public IActionResult CollectionBySession()
        {
            RoleOperation roleOperation = new RoleOperation("ProjectDashboard/Collection.Show");
            roleOperation.fn_checkRole();
            DashboardState dashboardState = new DashboardState();
            DashboardParameterState parameterState = new DashboardParameterState("OfficeId", Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value), typeof(Int32));

            //DashboardItemState gridFilterState = new DashboardItemState("gridDashboardItem1");
            //gridFilterState.MasterFilterValues.AddRange(new List<object[]>() {
            //    new string[1] { "Andrew Fuller" },
            //    new string[1] { "Laura Callahan" }
            //});

            //DashboardItemState treemapDrilldownState = new DashboardItemState("treemapDashboardItem1");
            //treemapDrilldownState.DrillDownValues.Add("Beverages");

            //DashboardItemState rangeFilterState = new DashboardItemState("rangeFilterDashboardItem1");
            //rangeFilterState.RangeFilterState.Selection =
            //    new RangeFilterSelection(new DateTime(2015, 1, 1), new DateTime(2016, 1, 1));

            dashboardState.Parameters.Add(parameterState);
            //dashboardState.Items.AddRange(new List<DashboardItemState>() {
            //    gridFilterState,
            //    treemapDrilldownState,
            //    rangeFilterState }
            //);

            DashboardControlModel dashboardControlModel = new DashboardControlModel { DashboardId = "3", WorkingMode = WorkingMode.ViewerOnly, DashboardState = dashboardState };
            return View("CollectionDashboardBySession", dashboardControlModel);
        }

        public IActionResult Expense()
        {
            RoleOperation roleOperation = new RoleOperation("ProjectDashboard/Expense.Show");
            roleOperation.fn_checkRole();
            DashboardState dashboardState = new DashboardState();
            DashboardParameterState parameterState = new DashboardParameterState("OfficeId", Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value), typeof(Int32));

            //DashboardItemState gridFilterState = new DashboardItemState("gridDashboardItem1");
            //gridFilterState.MasterFilterValues.AddRange(new List<object[]>() {
            //    new string[1] { "Andrew Fuller" },
            //    new string[1] { "Laura Callahan" }
            //});

            //DashboardItemState treemapDrilldownState = new DashboardItemState("treemapDashboardItem1");
            //treemapDrilldownState.DrillDownValues.Add("Beverages");

            //DashboardItemState rangeFilterState = new DashboardItemState("rangeFilterDashboardItem1");
            //rangeFilterState.RangeFilterState.Selection =
            //    new RangeFilterSelection(new DateTime(2015, 1, 1), new DateTime(2016, 1, 1));

            dashboardState.Parameters.Add(parameterState);
            //dashboardState.Items.AddRange(new List<DashboardItemState>() {
            //    gridFilterState,
            //    treemapDrilldownState,
            //    rangeFilterState }
            //);

            DashboardControlModel dashboardControlModel = new DashboardControlModel { DashboardId = "2", WorkingMode = WorkingMode.ViewerOnly, DashboardState = dashboardState };
            return View("ExpenseDashboard", dashboardControlModel);
        }
    }


}

public class DashboardControlModel
{
    public string DashboardId { get; set; }
    public WorkingMode WorkingMode { get; set; }
    public DashboardState DashboardState { get; set; }
}
