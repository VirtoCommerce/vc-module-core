using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.CoreModule.Web.Converters;
using VirtoCommerce.CoreModule.Web.Security;
using VirtoCommerce.Domain.Commerce.Services;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Domain.Order.Services;
using VirtoCommerce.Domain.Payment.Model;
using VirtoCommerce.Domain.Store.Services;
using VirtoCommerce.Platform.Core.Web.Security;
using coreModel = VirtoCommerce.Domain.Commerce.Model;
using coreTaxModel = VirtoCommerce.Domain.Tax.Model;
using webModel = VirtoCommerce.CoreModule.Web.Model;

namespace VirtoCommerce.CoreModule.Web.Controllers.Api
{
    [RoutePrefix("api")]
    public class CommerceController : ApiController
    {
        private readonly ICommerceService _commerceService;
        private readonly IStoreService _storeService;
        private readonly ISeoDuplicatesDetector _seoDuplicateDetector;

        public CommerceController(ICommerceService commerceService, IStoreService storeService, ISeoDuplicatesDetector seoDuplicateDetector)
        {
            _commerceService = commerceService;
            _storeService = storeService;
            _seoDuplicateDetector = seoDuplicateDetector;
        }


        /// <summary>
        /// Evaluate and return all tax rates for specified store and evaluation context 
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="evalContext"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(coreTaxModel.TaxRate[]))]
        [Route("taxes/{storeId}/evaluate")]
        public IHttpActionResult EvaluateTaxes(string storeId, [FromBody]coreTaxModel.TaxEvaluationContext evalContext)
        {
            var retVal = new List<coreTaxModel.TaxRate>();
            var store = _storeService.GetById(storeId);
            if (storeId != null)
            {
                var activeTaxProvider = store.TaxProviders.FirstOrDefault(x => x.IsActive);
                if (activeTaxProvider != null)
                {
                    evalContext.Store = store;
                    retVal.AddRange(activeTaxProvider.CalculateRates(evalContext));
                }
            }
            return Ok(retVal);
        }


        /// <summary>
        /// Return all fulfillment centers registered in the system
        /// </summary>
        [HttpGet]
        [ResponseType(typeof(coreModel.FulfillmentCenter[]))]
        [Route("fulfillment/centers")]
        public IHttpActionResult GetFulfillmentCenters()
        {
            var retVal = _commerceService.GetAllFulfillmentCenters().ToArray();
            return Ok(retVal);
        }

        /// <summary>
        /// Find fulfillment center by id
        /// </summary>
        /// <param name="id">fulfillment center id</param>
        [HttpGet]
        [ResponseType(typeof(coreModel.FulfillmentCenter))]
        [Route("fulfillment/centers/{id}")]
        public IHttpActionResult GetFulfillmentCenter(string id)
        {
            var retVal = _commerceService.GetAllFulfillmentCenters().First(x => x.Id == id);
            return Ok(retVal);
        }

        /// <summary>
        ///  Update a existing fulfillment center 
        /// </summary>
        /// <param name="center">fulfillment center</param>
        [HttpPut]
        [ResponseType(typeof(coreModel.FulfillmentCenter))]
        [Route("fulfillment/centers")]
        [CheckPermission(Permissions = new[] { CommercePredefinedPermissions.FulfillmentCreate, CommercePredefinedPermissions.FulfillmentUpdate })]
        [CLSCompliant(false)]
        public IHttpActionResult UpdateFulfillmentCenter(coreModel.FulfillmentCenter center)
        {
            var retVal = _commerceService.UpsertFulfillmentCenter(center);
            return Ok(retVal);
        }

        /// <summary>
        /// Delete  fulfillment centers registered in the system
        /// </summary>
        [HttpDelete]
        [ResponseType(typeof(void))]
        [Route("fulfillment/centers")]
        [CheckPermission(Permission = CommercePredefinedPermissions.FulfillmentDelete)]
        public IHttpActionResult DeleteFulfillmentCenters([FromUri] string[] ids)
        {
            _commerceService.DeleteFulfillmentCenter(ids);
            return StatusCode(HttpStatusCode.NoContent);
        }
    
        /// <summary>
        /// Batch create or update seo infos
        /// </summary>
        /// <param name="seoInfos"></param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("seoinfos/batchupdate")]
        public IHttpActionResult BatchUpdateSeoInfos(coreModel.SeoInfo[] seoInfos)
        {
            _commerceService.UpsertSeoInfos(seoInfos);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [ResponseType(typeof(coreModel.SeoInfo[]))]
        [Route("seoinfos/duplicates")]
        public IHttpActionResult GetSeoDuplicates(string objectId, string objectType)
        {
            var retVal = _seoDuplicateDetector.DetectSeoDuplicates(objectType, objectId, _commerceService.GetAllSeoDuplicates());
            return Ok(retVal.ToArray());
        }
        /// <summary>
        /// Find all SEO records for object by slug 
        /// </summary>
        /// <param name="slug">slug</param>
        [HttpGet]
        [ResponseType(typeof(coreModel.SeoInfo[]))]
        [Route("seoinfos/{slug}")]
        public IHttpActionResult GetSeoInfoBySlug(string slug)
        {
            var retVal = _commerceService.GetSeoByKeyword(slug).ToArray();
            return Ok(retVal);
        }

        /// <summary>
        /// Return all currencies registered in the system
        /// </summary>
        [HttpGet]
        [ResponseType(typeof(coreModel.Currency[]))]
        [Route("currencies")]
        public IHttpActionResult GetAllCurrencies()
        {
            var retVal = _commerceService.GetAllCurrencies().ToArray();
            return Ok(retVal);
        }

        /// <summary>
        ///  Update a existing currency 
        /// </summary>
        /// <param name="currency">currency</param>
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("currencies")]
        [CheckPermission(Permission = CommercePredefinedPermissions.CurrencyUpdate)]
        public IHttpActionResult UpdateCurrency(coreModel.Currency currency)
        {
            _commerceService.UpsertCurrencies(new[] { currency });
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        ///  Create new currency 
        /// </summary>
        /// <param name="currency">currency</param>
        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("currencies")]
        [CheckPermission(Permission = CommercePredefinedPermissions.CurrencyCreate)]
        public IHttpActionResult CreateCurrency(coreModel.Currency currency)
        {
            _commerceService.UpsertCurrencies(new[] { currency });
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        ///  Delete currencies 
        /// </summary>
        /// <param name="codes">currency codes</param>
        [HttpDelete]
        [ResponseType(typeof(void))]
        [Route("currencies")]
        [CheckPermission(Permission = CommercePredefinedPermissions.CurrencyDelete)]
        public IHttpActionResult DeleteCurrencies([FromUri] string[] codes)
        {
            _commerceService.DeleteCurrencies(codes);
            return StatusCode(HttpStatusCode.NoContent);
        }


        /// <summary>
        /// Return all package types registered in the system
        /// </summary>
        [HttpGet]
        [ResponseType(typeof(coreModel.PackageType[]))]
        [Route("packageTypes")]
        public IHttpActionResult GetAllPackageTypes()
        {
            var retVal = _commerceService.GetAllPackageTypes().ToArray();
            return Ok(retVal);
        }

        /// <summary>
        ///  Update a existing package type 
        /// </summary>
        /// <param name="packageType">package type</param>
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("packageTypes")]
        [CheckPermission(Permission = CommercePredefinedPermissions.PackageTypeUpdate)]
        public IHttpActionResult UpdatePackageType(coreModel.PackageType packageType)
        {
            _commerceService.UpsertPackageTypes(new[] { packageType });
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        ///  Create new package type 
        /// </summary>
        /// <param name="packageType">package type</param>
        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("packageTypes")]
        [CheckPermission(Permission = CommercePredefinedPermissions.PackageTypeCreate)]
        public IHttpActionResult CreatePackageType(coreModel.PackageType packageType)
        {
            _commerceService.UpsertPackageTypes(new[] { packageType });
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        ///  Delete package types 
        /// </summary>
        /// <param name="ids">package type ids</param>
        [HttpDelete]
        [ResponseType(typeof(void))]
        [Route("packageTypes")]
        [CheckPermission(Permission = CommercePredefinedPermissions.PackageTypeDelete)]
        public IHttpActionResult DeletePackageTypes([FromUri] string[] ids)
        {
            _commerceService.DeletePackageTypes(ids);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
