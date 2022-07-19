using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
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
        private Isp_GetPaymentService _sp_GetPaymentService;
        private Isp_GetSequentialPaymentService _sp_GetSequentialPaymentService;
        private Isp_GetListOfDriverInformationByOfficeIdService _sp_GetListOfDriverInformationByOfficeIdService;
        private ICollectionService _collectionService;
        private ICollectionDetailService _collectionDetailService;
        private ICollectionDefinitionService _collectionDefinitionService;

        public DriverController(IDriverInformationService driverInformationService, IDriverPaymentPlanService driverPaymentPlanService, 
            Isp_GetPaymentService sp_GetPaymentService, Isp_GetSequentialPaymentService sp_GetSequentialPaymentService, ICollectionService collectionService, 
            ICollectionDetailService collectionDetailService, ICollectionDefinitionService collectionDefinitionService,
            Isp_GetListOfDriverInformationByOfficeIdService sp_GetListOfDriverInformationByOfficeIdService)
        {
            _driverInformationService = driverInformationService;
            _driverPaymentPlanService = driverPaymentPlanService;
            _sp_GetPaymentService = sp_GetPaymentService;
            _sp_GetSequentialPaymentService = sp_GetSequentialPaymentService;
            _collectionService = collectionService;
            _collectionDetailService = collectionDetailService;
            _collectionDefinitionService = collectionDefinitionService;
            _sp_GetListOfDriverInformationByOfficeIdService = sp_GetListOfDriverInformationByOfficeIdService;
        }

        public IActionResult Index()
        {
            return View();
        }
                
        public IActionResult GetListOfDriverInformationByOfficeId()
        {
            var result = _sp_GetListOfDriverInformationByOfficeIdService.GetList(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value));
            if (result != null)
            {
                return Ok(result.Data);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        public IActionResult GetDriverByIdWithDetails(int id)
        {
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            dynamicResult.DriverInformation = new DriverInformation();
            dynamicResult.Sp_GetPayments = new List<sp_GetPayment>();
            dynamicResult.Sp_GetSequentialPaymentsYSH = new List<sp_GetSequentialPayment>();
            dynamicResult.Sp_GetSequentialPaymentsDSHFirst = new List<sp_GetSequentialPayment>();
            dynamicResult.Sp_GetPaymentsPlus = new List<sp_GetPayment>();
            dynamicResult.Sp_GetSequentialPaymentsDSHPlus = new List<sp_GetSequentialPayment>();
            dynamicResult.Sp_GetSequentialPaymentsPrivateLesson = new List<sp_GetSequentialPayment>();


            var result = _driverInformationService.GetByIdWithDetails(id);
            if (result.Success && result.Data!=null)
            {
                dynamicResult.DriverInformation = result.Data;

                var getPaymentsResult = _sp_GetPaymentService.GetByDriverInformationId(id, 10);
                dynamicResult.Sp_GetPayments = getPaymentsResult.Data;

                var getSequentialPaymentsYSHResult = _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(id, 30);
                dynamicResult.Sp_GetSequentialPaymentsYSH = getSequentialPaymentsYSHResult.Data;

                var getSequentialPaymentsDSHFirstResult = _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(id, 40);
                dynamicResult.Sp_GetSequentialPaymentsDSHFirst = getSequentialPaymentsDSHFirstResult.Data;

                var getPaymentsPlusResult = _sp_GetPaymentService.GetByDriverInformationId(id, 11);
                dynamicResult.Sp_GetPaymentsPlus = getPaymentsPlusResult.Data;

                var getSequentialPaymentsDSHPlusResult = _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(id, 41);
                dynamicResult.Sp_GetSequentialPaymentsDSHPlus = getSequentialPaymentsDSHPlusResult.Data;

                var getSequentialPaymentsPrivateLessonResult = _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(id, 50);
                dynamicResult.Sp_GetSequentialPaymentsPrivateLesson = getSequentialPaymentsPrivateLessonResult.Data;


                return View("AddEditDriver", dynamicResult);
            }

            return View("AddEditDriver", dynamicResult);

        }

        [HttpPost]
        public IActionResult AddDriver(DriverInformation driverInformation)
        {
            IResult driverInformationResult;

            driverInformation.OfficeId = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);
            if (driverInformation.Id == null || driverInformation.Id <= 0)
                driverInformationResult = _driverInformationService.Add(driverInformation);
            else
                driverInformationResult = _driverInformationService.Update(driverInformation);

            if (driverInformationResult.Success)
            {
                return Ok(driverInformation.Id);
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
        public IActionResult GetDriverPaymentPlanById(int id, int collectionDefinitionType)
        {
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            dynamicResult.DriverPaymentPlan = null;
            dynamicResult.CollectionDefinitionType = collectionDefinitionType;

            var result = _driverPaymentPlanService.GetById(id);
            if (result.Success)
            {
                dynamicResult.DriverPaymentPlan = result.Data;
                return PartialView("AddEditDriverPaymentPlan", dynamicResult);
            }

            return PartialView("AddEditDriverPaymentPlan", dynamicResult);

        }

        [HttpPost]
        public IActionResult AddDriverPaymentPlan(DriverPaymentPlan driverPaymentPlan)
        {        

            var driverPaymentPlanResult = _driverPaymentPlanService.GetById(driverPaymentPlan.Id);
            if (driverPaymentPlanResult.Success && driverPaymentPlanResult.Data!=null)
            {
                driverPaymentPlanResult.Data.UpdatedDateTime = DateTime.Now;
                driverPaymentPlanResult.Data.UpdatedUserName = User.Identity.Name;
                driverPaymentPlanResult.Data.PaymentDate = driverPaymentPlan.PaymentDate;
                driverPaymentPlanResult.Data.Amount = driverPaymentPlan.Amount;
                _driverPaymentPlanService.Update(driverPaymentPlanResult.Data);
            }
            else
            {
                driverPaymentPlan.AddedDateTime = DateTime.Now;
                driverPaymentPlan.AddedUserName = User.Identity.Name;
                driverPaymentPlan.UpdatedDateTime = driverPaymentPlan.AddedDateTime;
                driverPaymentPlan.UpdatedUserName = driverPaymentPlan.AddedUserName;
                driverPaymentPlan.Sequence = 0;
                _driverPaymentPlanService.Add(driverPaymentPlan);
            }

            

            var driverPaymentPlans = _driverPaymentPlanService.GetListByDriverInformationId(driverPaymentPlan.DriverInformationId, driverPaymentPlan.CollectionDefinitionType);
            if (driverPaymentPlans.Success && driverPaymentPlans.Data!=null && driverPaymentPlans.Data.Count>0)
            {
                int sequence = 0;
                foreach (var dr in driverPaymentPlans.Data.OrderBy(x => x.PaymentDate))
                {
                    sequence++;
                    dr.Sequence = sequence;
                }

                foreach (var dr in driverPaymentPlans.Data.OrderBy(x => x.PaymentDate))
                {
                    _driverPaymentPlanService.Update(dr);
                }
            }
            

            

            if (driverPaymentPlan.CollectionDefinitionType==10)
            {
                var getPaymentsResult = _sp_GetPaymentService.GetByDriverInformationId(driverPaymentPlan.DriverInformationId, 10);
                return PartialView("AddEditDriverCoursePayment", getPaymentsResult.Data);
            }
            else
            {
                var getPaymentsResult = _sp_GetPaymentService.GetByDriverInformationId(driverPaymentPlan.DriverInformationId, 11);
                return PartialView("AddEditDriverCoursePaymentPlus", getPaymentsResult.Data);
            }
            

        }

        [HttpGet]
        public IActionResult DeleteDriverPaymentPlanById(int id)
        {
            var driverId = 0;
            var collectionDefinitionType = 0;
            var driverPaymentPlanResult = _driverPaymentPlanService.GetById(id);
            if (driverPaymentPlanResult.Success && driverPaymentPlanResult.Data != null)
            {
                collectionDefinitionType = driverPaymentPlanResult.Data.CollectionDefinitionType;
                driverId = driverPaymentPlanResult.Data.DriverInformationId;
                _driverPaymentPlanService.Delete(driverPaymentPlanResult.Data);
            }



            var driverPaymentPlans = _driverPaymentPlanService.GetListByDriverInformationId(driverId, collectionDefinitionType);
            if (driverPaymentPlans.Success && driverPaymentPlans.Data != null && driverPaymentPlans.Data.Count > 0)
            {
                int sequence = 0;
                foreach (var dr in driverPaymentPlans.Data.OrderBy(x => x.PaymentDate))
                {
                    sequence++;
                    dr.Sequence = sequence;
                }

                foreach (var dr in driverPaymentPlans.Data.OrderBy(x => x.PaymentDate))
                {
                    _driverPaymentPlanService.Update(dr);
                }
            }

            if (collectionDefinitionType == 10)
            {
                var getPaymentsResult = _sp_GetPaymentService.GetByDriverInformationId(driverId, 10);

                return PartialView("AddEditDriverCoursePayment", getPaymentsResult.Data);
            }
            else
            {
                var getPaymentsPlusResult = _sp_GetPaymentService.GetByDriverInformationId(driverId, 11);

                return PartialView("AddEditDriverCoursePaymentPlus", getPaymentsPlusResult.Data);
            }


            

        }

        [HttpPost]
        public IActionResult NewHirePurchase(decimal courseFee, int collectionDefinitionType)
        {
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            dynamicResult.CourseFee = courseFee;
            dynamicResult.CollectionDefinitionType = collectionDefinitionType;
            return PartialView("HirePurchase", dynamicResult);
        }

        [HttpPost]
        public IActionResult AddDriverPaymentPlanWithHirePurchase(int driverId,DateTime hirePurchaseStartDate, int hirePurchaseCount, decimal courseFee, int collectionDefinitionType)
        {            
            var deletingDriverPaymentPlans = _driverPaymentPlanService.GetListByDriverInformationId(driverId, collectionDefinitionType);
            if (deletingDriverPaymentPlans.Success && deletingDriverPaymentPlans.Data.Where(x=>x.CollectionDefinitionType == collectionDefinitionType) != null && deletingDriverPaymentPlans.Data.Where(x => x.CollectionDefinitionType == collectionDefinitionType).Count() > 0)
            {
                foreach (var dr in deletingDriverPaymentPlans.Data.Where(x => x.CollectionDefinitionType == collectionDefinitionType))
                {
                    _driverPaymentPlanService.Delete(dr);
                }
            }

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
                driverPaymentPlans.Add(new DriverPaymentPlan { PaymentDate = hirePurchaseStartDate.AddMonths((i * -1)-1), Amount = amount, DriverInformationId = driverId, 
                    AddedDateTime = DateTime.Now, AddedUserName=User.Identity.Name, UpdatedDateTime=DateTime.Now, UpdatedUserName=User.Identity.Name, Sequence = (i*-1), CollectionDefinitionType = collectionDefinitionType});
            }

            foreach (var dr in driverPaymentPlans)
            {
                _driverPaymentPlanService.Add(dr);
            }

            if (collectionDefinitionType==10)
            {
                var getPaymentsResult = _sp_GetPaymentService.GetByDriverInformationId(driverId, 10);

                return PartialView("AddEditDriverCoursePayment", getPaymentsResult.Data);
            }
            else
            {
                var getPaymentsPlusResult = _sp_GetPaymentService.GetByDriverInformationId(driverId, 11);

                return PartialView("AddEditDriverCoursePaymentPlus", getPaymentsPlusResult.Data);
            }

            

        }

        [HttpGet]
        public IActionResult GetCollectionDetailByIdWithDetails(int id,string debit, int collectionDefinitionId, int collectionDefinitionTypeId)
        {            
            var result = _collectionDetailService.GetByIdWithDetails(id);
            ViewData["Debit"] = debit;
            ViewData["CollectionDefinitionId"] = collectionDefinitionId;
            ViewData["CollectionDefinitionTypeId"] = collectionDefinitionTypeId;            

            if (result.Success && result.Data!=null)
                return PartialView("AddEditDriverCollectionDetail", result.Data);
            else
            {
                CollectionDetail collectionDetail = new CollectionDetail();
                collectionDetail.CollectionDefinition = _collectionDefinitionService.GetByIdWithDetails(collectionDefinitionId).Data;
                return PartialView("AddEditDriverCollectionDetail", collectionDetail);
            }

            return PartialView("AddEditDriverCollectionDetail", result.Data);
        }

        [HttpGet]
        public IActionResult GetCollectionDetailsByIdWithDetails(string idList,string type)
        {
            List<CollectionDetail> collectionDetails = new List<CollectionDetail>();
            ViewData["Type"] = type;
            foreach (var id in idList.Split("/"))
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var result = _collectionDetailService.GetByIdWithDetails(Convert.ToInt32(id));
                    collectionDetails.Add(result.Data);
                }
                
            }

            return PartialView("CollectionDetailList", collectionDetails);
        }

        [HttpGet]
        public IActionResult GetAllCollectionDetailsByDriverInformationId(int driverId)
        {
            var result = _collectionDetailService.GetListWithDetailsByDriverInformationId(driverId);
            if (result!=null && result.Success)
            {
                return PartialView("CollectionDetailListOfDriver", result.Data);
            }

            return PartialView("CollectionDetailListOfDriver", result.Data);
        }

        void fn_AddEditDriverCollectionDetail(CollectionDetail collectionDetail, int driverId, int collectionId)
        {
            if (collectionId == 0)
            {
                Collection collection = new Collection();
                string documentNo = DateTime.Now.Year.ToString().Substring(2, 2) + "000000";
                var documentNoResult = _collectionService.GetLastDocumentNo(Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2)));
                if (documentNoResult.Success)
                {
                    documentNo = (documentNoResult.Message != null && !string.IsNullOrEmpty(documentNoResult.Message)) ? documentNoResult.Message : documentNo;
                }
                documentNo = documentNo.Substring(0, 2) + (Convert.ToInt32(documentNo.Substring(2, 6)) + 1).ToString().PadLeft(6, '0');

                if (collectionDetail.PaidBySelf)
                    collectionDetail.Amount = 0;

                collection.DocumentNo = documentNo;
                collection.DriverInformationId = driverId;
                collection.OfficeId = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);
                collection.CollectionDate = DateTime.Now.Date;
                collection.TotalAmount = collectionDetail.Amount;
                collection.AddedDateTime = DateTime.Now;
                collection.AddedUserName = User.Identity.Name;
                collection.UpdatedDateTime = collection.AddedDateTime;
                collection.UpdatedUserName = collection.AddedUserName;
                _collectionService.Add(collection);


                collectionDetail.CollectionId = collection.Id;
                collectionDetail.AddedDateTime = DateTime.Now;
                collectionDetail.AddedUserName = User.Identity.Name;
                collectionDetail.UpdatedDateTime = collectionDetail.AddedDateTime;
                collectionDetail.UpdatedUserName = collectionDetail.AddedUserName;

                _collectionDetailService.Add(collectionDetail);
            }
            else
            {
                var collectionResult = _collectionService.GetByIdWithDetails(collectionId);
                if (collectionResult.Success && collectionResult.Data != null)
                {
                    var collectionDetailResult = _collectionDetailService.GetByIdWithDetails(collectionDetail.Id);
                    if (collectionDetailResult.Success && collectionDetailResult.Data != null)
                    {
                        collectionResult.Data.TotalAmount -= collectionDetailResult.Data.Amount;
                    }

                    if (collectionDetail.PaidBySelf)
                        collectionDetail.Amount = 0;

                    collectionResult.Data.TotalAmount += collectionDetail.Amount;
                    collectionDetailResult.Data.PaidBySelf = collectionDetail.PaidBySelf;
                    collectionDetailResult.Data.Hour = collectionDetail.Hour;
                    collectionResult.Data.UpdatedDateTime = DateTime.Now;
                    collectionResult.Data.UpdatedUserName = User.Identity.Name;

                    collectionDetailResult.Data.Amount = collectionDetail.Amount;
                    collectionDetailResult.Data.PaymentTypeId = collectionDetail.PaymentTypeId;
                    collectionDetailResult.Data.UpdatedDateTime = collectionResult.Data.UpdatedDateTime;
                    collectionDetailResult.Data.UpdatedUserName = collectionResult.Data.UpdatedUserName;

                    collectionDetail.CollectionDefinitionId = collectionDetailResult.Data.CollectionDefinitionId;

                    _collectionDetailService.Update(collectionDetailResult.Data);
                    _collectionService.Update(collectionResult.Data);                    
                }
            }
        }

        [HttpPost]
        public IActionResult AddEditDriverCollectionDetail(CollectionDetail collectionDetail, int driverId, int collectionId)
        {
            fn_AddEditDriverCollectionDetail(collectionDetail,driverId,collectionId);

            int collectionDefinitionTypeId = _collectionDefinitionService.GetById(collectionDetail.CollectionDefinitionId).Data.CollectionDefinitionTypeId;

            switch (collectionDefinitionTypeId)
            {
                case 10 : return PartialView("AddEditDriverCoursePayment", _sp_GetPaymentService.GetByDriverInformationId(driverId, collectionDefinitionTypeId).Data);
                case 11 : return PartialView("AddEditDriverCoursePaymentPlus", _sp_GetPaymentService.GetByDriverInformationId(driverId, collectionDefinitionTypeId).Data);
                case 30 : return PartialView("AddEditDriverSequentialPaymentYSH", _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(driverId, collectionDefinitionTypeId).Data);
                case 40 : return PartialView("AddEditDriverSequentialPaymentDSHFirst", _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(driverId, collectionDefinitionTypeId).Data);
                case 41 : return PartialView("AddEditDriverSequentialPaymentDSHPlus", _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(driverId, collectionDefinitionTypeId).Data);
                case 50 : return PartialView("AddEditDriverSequentialPaymentPrivateLesson", _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(driverId, collectionDefinitionTypeId).Data);
            }

            return BadRequest("Error");
        }

        void fn_DeleteDriverCollectionDetailById(CollectionDetail collectionDetail)
        {
            var collectionResult = _collectionService.GetByIdWithDetails(collectionDetail.Collection.Id);
            if (collectionResult.Success && collectionResult.Data != null)
            {
                collectionResult.Data.TotalAmount -= collectionDetail.Amount;
                collectionResult.Data.UpdatedDateTime = DateTime.Now;
                collectionResult.Data.UpdatedUserName = User.Identity.Name;

                if (collectionResult.Data.TotalAmount == 0M)
                    _collectionService.Delete(collectionResult.Data);
                else
                {
                    _collectionDetailService.Delete(collectionDetail);
                    _collectionService.Update(collectionResult.Data);
                }

            }
        }

        [HttpPost]
        public IActionResult DeleteDriverCollectionDetailById(int id)
        {            
            int driverId = 0;
            var collectionDetailResult = _collectionDetailService.GetByIdWithDetails(id);
            if (collectionDetailResult.Success && collectionDetailResult.Data!=null)
            {
                driverId = collectionDetailResult.Data.Collection.DriverInformation.Id;

                fn_DeleteDriverCollectionDetailById(collectionDetailResult.Data);

                int collectionDefinitionTypeId = _collectionDefinitionService.GetById(collectionDetailResult.Data.CollectionDefinitionId).Data.CollectionDefinitionTypeId;

                switch (collectionDefinitionTypeId)
                {
                    case 10: return PartialView("AddEditDriverCoursePayment", _sp_GetPaymentService.GetByDriverInformationId(driverId, collectionDefinitionTypeId).Data);
                    case 11: return PartialView("AddEditDriverCoursePaymentPlus", _sp_GetPaymentService.GetByDriverInformationId(driverId, collectionDefinitionTypeId).Data);
                    case 30: return PartialView("AddEditDriverSequentialPaymentYSH", _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(driverId, collectionDefinitionTypeId).Data);
                    case 40: return PartialView("AddEditDriverSequentialPaymentDSHFirst", _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(driverId, collectionDefinitionTypeId).Data);
                    case 41: return PartialView("AddEditDriverSequentialPaymentDSHPlus", _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(driverId, collectionDefinitionTypeId).Data);
                    case 50: return PartialView("AddEditDriverSequentialPaymentPrivateLesson", _sp_GetSequentialPaymentService.GetByDriverInformationIdAndCollectionDefinitionTypeId(driverId, collectionDefinitionTypeId).Data);
                }              

            }

            return BadRequest(collectionDetailResult.Message);

        }

        [HttpPost]
        public IActionResult PrintDriverCollectionDetail(int id)
        { 
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            var detailResult = _collectionDetailService.GetByIdWithDetails(id);
            if (detailResult.Success && detailResult.Data != null)
            {
                dynamicResult.CollectionDetail = detailResult.Data;
                dynamicResult.AmountToWord = ConvertDecimalToWord.convert(detailResult.Data.Amount);
                return PartialView("PrintDriverCollectionDetail", dynamicResult);
            }

            return PartialView("PrintDriverCollectionDetail", dynamicResult);
        }

        [HttpPost]
        public IActionResult PrintAddressForm(int id)
        {
            //dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            var result = _driverInformationService.GetByIdWithDetails(id);
            if (result.Success && result.Data != null)
            {
                return PartialView("PrintAddressForm", result.Data);
            }

            return PartialView("PrintAddressForm", result.Data);
        }

        [HttpPost]
        public IActionResult PrintApplicationForm(int id)
        {
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            dynamicResult.DriverInformation = new DriverInformation();
            dynamicResult.DriverPaymentPlan = new List<sp_GetPayment>();

            var result = _driverInformationService.GetByIdWithDetails(id);
            if (result.Success && result.Data != null)
            {
                dynamicResult.DriverInformation = result.Data;

                var getDriverPaymentPlanResult = _driverPaymentPlanService.GetListByDriverInformationId(id,10);
                dynamicResult.DriverPaymentPlan = getDriverPaymentPlanResult.Data;


                return PartialView("PrintApplicationForm", dynamicResult);
            }


            return PartialView("PrintApplicationForm", dynamicResult);
        }

    }
}
