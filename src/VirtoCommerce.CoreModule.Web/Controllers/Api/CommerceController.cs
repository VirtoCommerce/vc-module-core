using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtoCommerce.CoreModule.Core;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.CoreModule.Core.Currency;
using VirtoCommerce.CoreModule.Core.Package;

namespace VirtoCommerce.CoreModule.Web.Controllers.Api
{
    [Route("api")]
    public class CommerceController : Controller
    {
        private readonly ICurrencyService _currencyService;
        private readonly IPackageTypesService _packageTypesService;
        public CommerceController(ICurrencyService currencyService, IPackageTypesService packageTypesService)
        {
            _currencyService = currencyService;
            _packageTypesService = packageTypesService;
        }

        /// <summary>
        /// Return all currencies registered in the system
        /// </summary>
        [HttpGet]
        [Route("currencies")]
        public async Task<ActionResult<Currency[]>> GetAllCurrencies()
        {
            var retVal = await _currencyService.GetAllCurrenciesAsync();
            return Ok(retVal.ToArray());
        }

        /// <summary>
        ///  Create a existing currency 
        /// </summary>
        /// <param name="currency">currency</param>
        [HttpPost]
        [Route("currencies")]
        [Authorize(ModuleConstants.Security.Permissions.CurrencyCreate)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> CreateCurrency([FromBody] Currency currency)
        {
            await _currencyService.SaveChangesAsync(new[] { currency });
            return NoContent();
        }

        /// <summary>
        ///  Update a existing currency 
        /// </summary>
        /// <param name="currency">currency</param>
        [HttpPut]
        [Route("currencies")]
        [Authorize(ModuleConstants.Security.Permissions.CurrencyUpdate)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateCurrency([FromBody] Currency currency)
        {
            await _currencyService.SaveChangesAsync(new[] { currency });
            return NoContent();
        }


        /// <summary>
        ///  Delete currencies 
        /// </summary>
        /// <param name="codes">currency codes</param>
        [HttpDelete]
        [Route("currencies")]
        [Authorize(ModuleConstants.Security.Permissions.CurrencyDelete)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteCurrencies([FromQuery] string[] codes)
        {
            await _currencyService.DeleteCurrenciesAsync(codes);
            return NoContent();
        }


        /// <summary>
        /// Return all package types registered in the system
        /// </summary>
        [HttpGet]
        [Route("packageTypes")]
        public async Task<ActionResult<PackageType[]>> GetAllPackageTypes()
        {
            var retVal = await _packageTypesService.GetAllPackageTypesAsync();
            return Ok(retVal.ToArray());
        }

        /// <summary>
        ///  Update a existing package type 
        /// </summary>
        /// <param name="packageType">package type</param>
        [HttpPut]
        [Route("packageTypes")]
        [Authorize(ModuleConstants.Security.Permissions.PackageTypeUpdate)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdatePackageType([FromBody] PackageType packageType)
        {
            await _packageTypesService.SaveChangesAsync(new[] { packageType });
            return NoContent();
        }

        /// <summary>
        ///  Create new package type 
        /// </summary>
        /// <param name="packageType">package type</param>
        [HttpPost]
        [Route("packageTypes")]
        [Authorize(ModuleConstants.Security.Permissions.PackageTypeCreate)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> CreatePackageType([FromBody] PackageType packageType)
        {
            await _packageTypesService.SaveChangesAsync(new[] { packageType });
            return NoContent();
        }

        /// <summary>
        ///  Delete package types 
        /// </summary>
        /// <param name="ids">package type ids</param>
        [HttpDelete]
        [Route("packageTypes")]
        [Authorize(ModuleConstants.Security.Permissions.PackageTypeDelete)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeletePackageTypes([FromQuery] string[] ids)
        {
            await _packageTypesService.DeletePackageTypesAsync(ids);
            return NoContent();
        }

        /// <summary>
        /// Validate address (reserved for future) and also required for expose Address in OpenAPI swagger docs
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<bool> ValidateAddress([FromBody] Address address)
        {
            return Ok(address != null);
        }
    }
}
