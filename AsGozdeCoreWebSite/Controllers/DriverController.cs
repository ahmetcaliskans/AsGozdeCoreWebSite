using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Controllers
{
    public class DriverController : Controller
    {
        private IDriverInformationService _driverInformationService;
        private IDriverPaymentPlanService _driverPaymentPlanService;

        public DriverController (IDriverInformationService driverInformationService, IDriverPaymentPlanService driverPaymentPlanService)
        {
            _driverInformationService = driverInformationService;
            _driverPaymentPlanService = driverPaymentPlanService;
        }

        public IActionResult Index()
        {
            var result = _driverInformationService.GetListWithDetails(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value));
            if (result != null)
            {
                return View(result.Data.OrderByDescending(x=> x.Session.Year).ThenByDescending(x=>x.Session.Sequence).ThenByDescending(x=>x.Id).ToList());
            }

            return View();
        }


        [HttpGet]
        public IActionResult GetDriverByIdWithDetails(int id)
        {
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            dynamicResult.DriverInformation = new DriverInformation();
            dynamicResult.DriverPaymentPlans = new List<DriverPaymentPlan>();
            
            HttpContext.Session.SetString("DriverPaymentPlans", JsonConvert.SerializeObject(dynamicResult.DriverPaymentPlans as List<DriverPaymentPlan>, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

            var result = _driverInformationService.GetByIdWithDetails(id);
            if (result.Success && result.Data!=null)
            {
                if (result.Data != null && result.Data.DriverPaymentPlans != null && result.Data.DriverPaymentPlans.Count > 0)
                    HttpContext.Session.SetString("DriverPaymentPlans", JsonConvert.SerializeObject(result.Data.DriverPaymentPlans as List<DriverPaymentPlan>, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

                dynamicResult.DriverInformation = result.Data;
                dynamicResult.DriverPaymentPlans = result.Data.DriverPaymentPlans;

                return View("AddEditDriver", dynamicResult);
            }

            return View("AddEditDriver", dynamicResult);

        }

        [HttpPost]
        public IActionResult AddDriver(DriverInformation driverInformation)
        {
            var driverPaymentPlanSession = JsonConvert.DeserializeObject<List<DriverPaymentPlan>>(HttpContext.Session.GetString("DriverPaymentPlans"), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            
            if (driverPaymentPlanSession!=null ||driverPaymentPlanSession.Count>0)
            {
                int sequence = 0;
                foreach (var dr in driverPaymentPlanSession.OrderBy(x => x.PaymentDate))
                {
                    sequence++;
                    dr.Sequence = sequence;
                }
            }


            IResult driverInformationResult;
            IResult driverPaymentPlanResult;

            driverInformation.OfficeId = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);
            if (driverInformation.Id == null || driverInformation.Id <= 0)
            {
                driverInformationResult = _driverInformationService.Add(driverInformation);

                foreach (var dr in driverPaymentPlanSession)
                {
                    dr.Id = 0;
                    dr.DriverInformationId = driverInformation.Id;
                    dr.AddedDateTime = DateTime.Now;
                    dr.AddedUserName = User.Identity.Name;
                    dr.UpdatedDateTime = dr.AddedDateTime;
                    dr.UpdatedUserName = dr.AddedUserName;
                    driverPaymentPlanResult = _driverPaymentPlanService.Add(dr);
                }
                
            }                
            else
            {
                var driverPaymenPlansFromDB = _driverPaymentPlanService.GetListByDriverInformationId(driverInformation.Id);
                if (driverPaymenPlansFromDB.Success)
                {
                    List<DriverPaymentPlan> deletedDriverPaymentPlans = new List<DriverPaymentPlan>();
                    foreach (var dt in driverPaymenPlansFromDB.Data)
                    {
                        var checkPaymentPlan = driverPaymentPlanSession.Where(x => x.Id > 0 && x.Id == dt.Id);
                        if (checkPaymentPlan != null && checkPaymentPlan.Count() > 0)
                        {
                            var dr = checkPaymentPlan.FirstOrDefault();
                            if (dr.UpdatedDateTime!=null && (dr.UpdatedDateTime!=dt.UpdatedDateTime || dr.Sequence!=dt.Sequence))
                            {
                                dr.UpdatedDateTime = DateTime.Now;
                                dr.UpdatedUserName = User.Identity.Name;
                                driverPaymentPlanResult = _driverPaymentPlanService.Update(dr);
                            }
                            
                        }
                        else
                        {
                            driverPaymentPlanResult = _driverPaymentPlanService.Delete(dt);
                        }
                    }


                    if (driverPaymentPlanSession.Count() > 0)
                    {
                        foreach (var dr in driverPaymentPlanSession)
                        {
                            dr.Id = 0;
                            dr.DriverInformationId = driverInformation.Id;
                            dr.AddedDateTime = DateTime.Now;
                            dr.AddedUserName = User.Identity.Name;
                            dr.UpdatedDateTime = dr.AddedDateTime;
                            dr.UpdatedUserName = dr.AddedUserName;
                            driverPaymentPlanResult = _driverPaymentPlanService.Add(dr);
                        }
                    }

                }


                driverInformationResult = _driverInformationService.Update(driverInformation);
            }       
            



            if (driverInformationResult.Success)
            {
                return Ok(driverInformationResult.Message);
            }

            return BadRequest(driverInformationResult.Message);


        }

        [HttpPost]
        public IActionResult DeleteDriverById(int id)
        {
            var _driverResult = _driverInformationService.GetById(id);

            var result = _driverInformationService.Delete(_driverResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }


        [HttpGet]
        public IActionResult GetDriverPaymentPlanById(int id)
        {
            var driverPaymentPlanResult = JsonConvert.DeserializeObject<List<DriverPaymentPlan>>(HttpContext.Session.GetString("DriverPaymentPlans"), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            var result = new SuccessDataResult<DriverPaymentPlan>(driverPaymentPlanResult.Where(x => x.Id == id).FirstOrDefault(), Messages.Added);

            if (result.Success)
            {
                return PartialView("AddEditDriverPaymentPlan", result.Data);
            }

            return PartialView("AddEditDriverPaymentPlan", result.Data);

        }

        [HttpPost]
        public IActionResult AddDriverPaymentPlan(DriverPaymentPlan driverPaymentPlan)
        {
            driverPaymentPlan.UpdatedDateTime = DateTime.Now;
            var driverPaymentPlanResult = JsonConvert.DeserializeObject<List<DriverPaymentPlan>>(HttpContext.Session.GetString("DriverPaymentPlans"), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            if (driverPaymentPlanResult.Count > 0)
            {
                var _dr = driverPaymentPlanResult.Where(x => x.Id == driverPaymentPlan.Id);
                if (_dr != null && _dr.Count() > 0)
                {
                    foreach (var dr in _dr)
                    {
                        dr.PaymentDate = driverPaymentPlan.PaymentDate;
                        dr.Amount = driverPaymentPlan.Amount;
                        dr.UpdatedDateTime = driverPaymentPlan.UpdatedDateTime;
                    }
                }
                else
                {
                    driverPaymentPlan.Id = (int)driverPaymentPlanResult.Min(x => x.Id) > 0 ? -1 : (int)driverPaymentPlanResult.Min(x => x.Id) - 1;
                    driverPaymentPlanResult.Add(driverPaymentPlan);
                }
            }
            else
            {
                driverPaymentPlan.Id = -1;
                driverPaymentPlanResult.Add(driverPaymentPlan);
            }

            int sequence = 0;
            foreach (var dr in driverPaymentPlanResult.OrderBy(x=> x.PaymentDate))
            {
                sequence++;
                dr.Sequence = sequence;
            }

            HttpContext.Session.SetString("DriverPaymentPlans", JsonConvert.SerializeObject(driverPaymentPlanResult, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

            return PartialView("ListDriverPaymentPlan", driverPaymentPlanResult);


        }

        [HttpGet]
        public IActionResult DeleteDriverPaymentPlanById(int id)
        {
            var driverPaymentPlanResult = JsonConvert.DeserializeObject<List<DriverPaymentPlan>>(HttpContext.Session.GetString("DriverPaymentPlans"), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            driverPaymentPlanResult.Remove(driverPaymentPlanResult.Where(x => x.Id == id).FirstOrDefault());
            HttpContext.Session.SetString("DriverPaymentPlans", JsonConvert.SerializeObject(driverPaymentPlanResult, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

            return PartialView("ListDriverPaymentPlan", driverPaymentPlanResult);

        }

        [HttpPost]
        public IActionResult NewHirePurchase(decimal courseFee)
        {
            return PartialView("HirePurchase", courseFee);
        }

        [HttpPost]
        public IActionResult AddDriverPaymentPlanWithHirePurchase(DateTime hirePurchaseStartDate, int hirePurchaseCount, decimal courseFee)
        {
            var driverPaymentPlans = new List<DriverPaymentPlan>();
            decimal totalAmount = 0M;
            decimal amount = Math.Round(courseFee / hirePurchaseCount, 2);
            for (int i = -1; i >= (hirePurchaseCount*-1); i--)
            {
                totalAmount += amount;
                if (i==(hirePurchaseCount*-1) && totalAmount!=courseFee)
                {
                    amount += courseFee - totalAmount;
                }
                driverPaymentPlans.Add(new DriverPaymentPlan { Id = i, PaymentDate = hirePurchaseStartDate.AddMonths((i * -1)-1), Amount = amount, UpdatedDateTime = DateTime.Now , Sequence = (i*-1)});
            }
            HttpContext.Session.SetString("DriverPaymentPlans", JsonConvert.SerializeObject(driverPaymentPlans, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

            return PartialView("ListDriverPaymentPlan", driverPaymentPlans);

        }

    }
}
