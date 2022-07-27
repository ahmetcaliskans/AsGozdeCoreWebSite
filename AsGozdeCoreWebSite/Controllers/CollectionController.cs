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
    public class CollectionController : Controller
    {
        private ICollectionService _collectionService;
        private ICollectionDetailService _collectionDetailService;
        private IPaymentTypeService _paymentTypeService;
        private ICollectionDefinitionService _collectionDefinitionService;
        private IDriverInformationService _driverInformationService;
        private IOfficeService _officeService;
        private Isp_GetListOfCollectionByOfficeIdService _sp_GetListOfCollectionByOfficeIdService;

        public CollectionController(ICollectionService collectionService, ICollectionDetailService collectionDetailService,IPaymentTypeService paymentTypeService, 
            ICollectionDefinitionService collectionDefinitionService, IDriverInformationService driverInformationService, IOfficeService officeService,
            Isp_GetListOfCollectionByOfficeIdService sp_GetListOfCollectionByOfficeIdService)
        {
            _collectionService = collectionService;
            _collectionDetailService = collectionDetailService;
            _paymentTypeService = paymentTypeService;
            _collectionDefinitionService = collectionDefinitionService;
            _driverInformationService = driverInformationService;
            _officeService = officeService;
            _sp_GetListOfCollectionByOfficeIdService = sp_GetListOfCollectionByOfficeIdService;
        }
        public IActionResult Index()
        {
            //var result = _collectionService.GetListWithDetailsByOfficeId(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value));
            //if (result != null)
            //{
            //    return View(result.Data.OrderByDescending(x => x.CollectionDate).ThenByDescending(x=>x.Id).ToList());
            //}

            return View();
        }

        public IActionResult GetListOfCollectionByOfficeId()
        {
            var result = _sp_GetListOfCollectionByOfficeIdService.GetList(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value));
            if (result != null)
            {
                return Ok(result.Data);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        public IActionResult GetCollectionByIdWithDetails(int id)
        {
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            dynamicResult.Collection = new Collection();
            dynamicResult.Collection.DriverInformation = new DriverInformation();
            dynamicResult.CollectionDetails = new List<CollectionDetail>();

            HttpContext.Session.SetString("Collection", JsonConvert.SerializeObject(dynamicResult.Collection as Collection, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            HttpContext.Session.SetString("CollectionDetails", JsonConvert.SerializeObject(dynamicResult.CollectionDetails as List<CollectionDetail>, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

            var result = _collectionService.GetByIdWithDetails(id);
            if (result.Success && result.Data!=null)
            {
                var detailResult = _collectionDetailService.GetListWithDetailsByCollectionId(id);
                HttpContext.Session.SetString("Collection", JsonConvert.SerializeObject(result.Data, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                HttpContext.Session.SetString("CollectionDetails", JsonConvert.SerializeObject(detailResult.Data, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

                dynamicResult.Collection = result.Data;
                dynamicResult.CollectionDetails = detailResult.Data;
                return View("AddEditCollection", dynamicResult);
            }

            return View("AddEditCollection", dynamicResult);
        }

        [HttpPost]
        public IActionResult AddCollection(DateTime collectionDate)
        {
            var collectionSession = JsonConvert.DeserializeObject<Collection>(HttpContext.Session.GetString("Collection"), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            var collectionDetailSession = JsonConvert.DeserializeObject<List<CollectionDetail>>(HttpContext.Session.GetString("CollectionDetails"), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            if (collectionSession==null)
            {
                return BadRequest("Hata");
            }

            if (collectionDetailSession == null || collectionDetailSession.Count == 0)
            {
                return BadRequest("Hata");
            }

            IResult collectionResult;
            IResult collectionDetailsResult;
            if(collectionSession.OfficeId==0)
            {
                collectionSession.OfficeId = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);
                //collectionSession.Office = _officeService.GetById(collectionSession.OfficeId).Data;
            }

            collectionSession.CollectionDate = collectionDate;
            collectionSession.TotalAmount = collectionDetailSession.Sum(x => x.Amount);
            collectionSession.UpdatedDateTime = DateTime.Now;
            collectionSession.UpdatedUserName = User.Identity.Name;

            if (collectionSession.Id == null || collectionSession.Id <= 0)
            {
                collectionSession.AddedDateTime = collectionSession.UpdatedDateTime;
                collectionSession.AddedUserName = collectionSession.UpdatedUserName;

                string documentNo = collectionDate.Year.ToString().Substring(2, 2) + "000000";
                var documentNoResult = _collectionService.GetLastDocumentNo(Convert.ToInt32(collectionDate.Year.ToString().Substring(2, 2)));
                if (documentNoResult.Success)
                {
                    documentNo = (documentNoResult.Message != null && !string.IsNullOrEmpty(documentNoResult.Message)) ? documentNoResult.Message : documentNo;
                }
                documentNo = documentNo.Substring(0, 2) + (Convert.ToInt32(documentNo.Substring(2, 6)) + 1).ToString().PadLeft(6, '0');
                collectionSession.DocumentNo = documentNo;
                collectionResult = _collectionService.Add(collectionSession);

                foreach (var dr in collectionDetailSession)
                {
                    dr.Id = 0;
                    dr.CollectionId = collectionSession.Id;
                    dr.AddedDateTime = collectionSession.UpdatedDateTime;
                    dr.AddedUserName = collectionSession.UpdatedUserName;
                    dr.UpdatedDateTime = dr.AddedDateTime;
                    dr.UpdatedUserName = dr.AddedUserName;
                    collectionDetailsResult = _collectionDetailService.Add(dr);
                }
            }                
            else
            {        

                var collectionDetailsFromDB = _collectionDetailService.GetListWithDetailsByCollectionId(collectionSession.Id);
                if (collectionDetailsFromDB.Success)
                {
                    List<CollectionDetail> deletedCollectionDetails = new List<CollectionDetail>();
                    foreach (var dt in collectionDetailsFromDB.Data)
                    {
                        var checkDetail = collectionDetailSession.Where(x => x.Id > 0 && x.Id == dt.Id);
                        if (checkDetail!=null && checkDetail.Count()>0)
                        {
                            var dr = checkDetail.FirstOrDefault();
                            dr.UpdatedDateTime = collectionSession.UpdatedDateTime;
                            dr.UpdatedUserName = collectionSession.UpdatedUserName;
                            _collectionDetailService.Update(dr);
                        }
                        else
                        {
                            _collectionDetailService.Delete(dt);
                        }
                    }


                    if (collectionDetailSession.Where(x => x.Id <= 0).Count()>0)
                    {
                        foreach (var dr in collectionDetailSession.Where(x => x.Id <= 0))
                        {
                            dr.Id = 0;
                            dr.CollectionId = collectionSession.Id;
                            dr.Collection = collectionSession;
                            dr.AddedDateTime = collectionSession.UpdatedDateTime;
                            dr.AddedUserName = collectionSession.UpdatedUserName;
                            dr.UpdatedDateTime = dr.AddedDateTime;
                            dr.UpdatedUserName = dr.AddedUserName;
                            _collectionDetailService.Add(dr);
                        }
                    }

                }

                collectionResult = _collectionService.Update(collectionSession);

            }
                


            if (collectionResult.Success)
            {                
                return Ok(new string[] { collectionResult.Message , collectionSession.Id.ToString() });
            }

            return BadRequest(collectionResult.Message);

        }

        [HttpPost]
        public IActionResult DeleteCollectionById(int id)
        {
            var _collectionResult = _collectionService.GetById(id);

            var result = _collectionService.Delete(_collectionResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);

        }

        [HttpPost]
        public IActionResult PrintCollection(int id)
        {
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            var result = _collectionService.GetByIdWithDetails(id);
            if (result.Success && result.Data != null)
            {
                var detailResult = _collectionDetailService.GetListWithDetailsByCollectionId(id);

                dynamicResult.Collection = result.Data;
                dynamicResult.CollectionDetails = detailResult.Data;
                dynamicResult.AmountToWord = ConvertDecimalToWord.convert(result.Data.TotalAmount);
                return PartialView("PrintCollection", dynamicResult);
            }

            return PartialView("PrintCollection", dynamicResult);
        }


        #region Collection Detail
        [HttpGet]
        public IActionResult GetCollectionDetailByIdWithDetails(int id)
        {
            var collectionDetailResult = JsonConvert.DeserializeObject<List<CollectionDetail>>(HttpContext.Session.GetString("CollectionDetails"), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            var result = new SuccessDataResult<CollectionDetail>(collectionDetailResult.Where(x => x.Id == id).FirstOrDefault(), Messages.Added);
            ViewData["PayBySelf"] = false;
            ViewData["CollectionDefinitionTypeId"] = 99;

            if (result.Success && result.Data != null)
            {
                ViewData["PayBySelf"] = result.Data.CollectionDefinition.PayBySelf;
                ViewData["CollectionDefinitionTypeId"] = result.Data.CollectionDefinition.CollectionDefinitionTypeId;
                return PartialView("AddEditCollectionDetail", result.Data);
            }

            return PartialView("AddEditCollectionDetail", result.Data);
        }

        [HttpPost]
        public IActionResult AddCollectionDetail(CollectionDetail collectionDetail)
        {
            var collectionDetailResult = JsonConvert.DeserializeObject<List<CollectionDetail>>(HttpContext.Session.GetString("CollectionDetails"), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            if (collectionDetailResult.Count>0)
            {
                var _dr = collectionDetailResult.Where(x => x.Id == collectionDetail.Id);
                if (_dr!=null && _dr.Count()>0)
                {
                    foreach (var dr in _dr)
                    {
                        dr.Amount = collectionDetail.Amount;
                        dr.Hour = collectionDetail.Hour;
                        dr.PaidBySelf = collectionDetail.PaidBySelf;
                        if (dr.PaymentTypeId!=collectionDetail.PaymentTypeId)
                        {
                            dr.PaymentTypeId = collectionDetail.PaymentTypeId;
                            dr.PaymentType = _paymentTypeService.GetById(collectionDetail.PaymentTypeId).Data;
                        }
                        if (dr.CollectionDefinitionId != collectionDetail.CollectionDefinitionId)
                        {
                            dr.CollectionDefinitionId = collectionDetail.CollectionDefinitionId;
                            dr.CollectionDefinition = _collectionDefinitionService.GetById(collectionDetail.CollectionDefinitionId).Data;
                        }       
                        
                        
                    }
                }
                else
                {
                    collectionDetail.Id = (int)collectionDetailResult.Min(x => x.Id) > 0 ? -1 : (int)collectionDetailResult.Min(x => x.Id) - 1;
                    collectionDetail.PaymentType = _paymentTypeService.GetById(collectionDetail.PaymentTypeId).Data;
                    collectionDetail.CollectionDefinition = _collectionDefinitionService.GetById(collectionDetail.CollectionDefinitionId).Data;
                    collectionDetailResult.Add(collectionDetail);
                }
            }
            else
            {
                collectionDetail.Id = -1;
                collectionDetail.PaymentType = _paymentTypeService.GetById(collectionDetail.PaymentTypeId).Data;
                collectionDetail.CollectionDefinition = _collectionDefinitionService.GetById(collectionDetail.CollectionDefinitionId).Data;
                collectionDetailResult.Add(collectionDetail);
            }

            if (collectionDetail.PaidBySelf)
                collectionDetail.Amount = 0M;

            HttpContext.Session.SetString("CollectionDetails", JsonConvert.SerializeObject(collectionDetailResult, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));            

            return PartialView("ListCollectionDetail", collectionDetailResult);

        }

        [HttpGet]
        public IActionResult DeleteCollectionDetailById(int id)
        {
            var collectionDetailResult = JsonConvert.DeserializeObject<List<CollectionDetail>>(HttpContext.Session.GetString("CollectionDetails"), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });            
            collectionDetailResult.Remove(collectionDetailResult.Where(x => x.Id == id).FirstOrDefault());
            HttpContext.Session.SetString("CollectionDetails", JsonConvert.SerializeObject(collectionDetailResult, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));            

            return PartialView("ListCollectionDetail", collectionDetailResult);

        }

        [HttpGet]
        public IActionResult GetDriverInformationsWithDetails()
        {
            //var result = _driverInformationService.GetListWithDetails(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value));
            //if (result.Success)
            //{
            //    return PartialView("ListDriverInformation", result.Data);
            //}

            return PartialView("ListDriverInformation");
        }

        [HttpGet]
        public IActionResult GetDriverInformationByIdWithDetails(int id)
        {
            var collectionSession = JsonConvert.DeserializeObject<Collection>(HttpContext.Session.GetString("Collection"), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            var result = _driverInformationService.GetByIdWithDetails(id);
            if (result.Success)
            {
                collectionSession.DriverInformationId = result.Data.Id;
                collectionSession.DriverInformation = result.Data;
                HttpContext.Session.SetString("Collection", JsonConvert.SerializeObject(collectionSession, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                return PartialView("DriverInformation",result.Data);
            }

            return PartialView("DriverInformation", result.Data);
        }

        [HttpPost]
        public IActionResult GetCollectionDefinitionInformations(int id)
        {
            var result = _collectionDefinitionService.GetByIdWithDetails(id);
            ViewData["PayBySelf"] = false;
            ViewData["CollectionDefinitionTypeId"] = 99;

            if (result.Success && result.Data != null)
            {
                ViewData["PayBySelf"] = result.Data.PayBySelf;
                ViewData["CollectionDefinitionTypeId"] = result.Data.CollectionDefinitionTypeId;
                return Ok(string.Format("{0}/{1}", result.Data.PayBySelf,result.Data.CollectionDefinitionTypeId));
            }
            return Ok();
        }

        #endregion
    }
}
