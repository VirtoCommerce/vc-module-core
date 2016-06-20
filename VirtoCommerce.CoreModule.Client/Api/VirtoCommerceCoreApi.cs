using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using VirtoCommerce.CoreModule.Client.Client;
using VirtoCommerce.CoreModule.Client.Model;

namespace VirtoCommerce.CoreModule.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IVirtoCommerceCoreApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Batch create or update seo infos
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="seoInfos"></param>
        /// <returns></returns>
        void CommerceBatchUpdateSeoInfos(List<SeoInfo> seoInfos);

        /// <summary>
        /// Batch create or update seo infos
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="seoInfos"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CommerceBatchUpdateSeoInfosWithHttpInfo(List<SeoInfo> seoInfos);
        /// <summary>
        /// Create new currency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns></returns>
        void CommerceCreateCurrency(Currency currency);

        /// <summary>
        /// Create new currency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CommerceCreateCurrencyWithHttpInfo(Currency currency);
        /// <summary>
        /// Delete currencies
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="codes">currency codes</param>
        /// <returns></returns>
        void CommerceDeleteCurrencies(List<string> codes);

        /// <summary>
        /// Delete currencies
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="codes">currency codes</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CommerceDeleteCurrenciesWithHttpInfo(List<string> codes);
        /// <summary>
        /// Delete  fulfillment centers registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ids"></param>
        /// <returns>List&lt;FulfillmentCenter&gt;</returns>
        List<FulfillmentCenter> CommerceDeleteFulfillmentCenters(List<string> ids);

        /// <summary>
        /// Delete  fulfillment centers registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ids"></param>
        /// <returns>ApiResponse of List&lt;FulfillmentCenter&gt;</returns>
        ApiResponse<List<FulfillmentCenter>> CommerceDeleteFulfillmentCentersWithHttpInfo(List<string> ids);
        /// <summary>
        /// Evaluate and return all tax rates for specified store and evaluation context
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="storeId"></param>
        /// <param name="evalContext"></param>
        /// <returns>List&lt;TaxRate&gt;</returns>
        List<TaxRate> CommerceEvaluateTaxes(string storeId, TaxEvaluationContext evalContext);

        /// <summary>
        /// Evaluate and return all tax rates for specified store and evaluation context
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="storeId"></param>
        /// <param name="evalContext"></param>
        /// <returns>ApiResponse of List&lt;TaxRate&gt;</returns>
        ApiResponse<List<TaxRate>> CommerceEvaluateTaxesWithHttpInfo(string storeId, TaxEvaluationContext evalContext);
        /// <summary>
        /// Return all currencies registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Currency&gt;</returns>
        List<Currency> CommerceGetAllCurrencies();

        /// <summary>
        /// Return all currencies registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Currency&gt;</returns>
        ApiResponse<List<Currency>> CommerceGetAllCurrenciesWithHttpInfo();
        /// <summary>
        /// Find fulfillment center by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">fulfillment center id</param>
        /// <returns>FulfillmentCenter</returns>
        FulfillmentCenter CommerceGetFulfillmentCenter(string id);

        /// <summary>
        /// Find fulfillment center by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">fulfillment center id</param>
        /// <returns>ApiResponse of FulfillmentCenter</returns>
        ApiResponse<FulfillmentCenter> CommerceGetFulfillmentCenterWithHttpInfo(string id);
        /// <summary>
        /// Return all fulfillment centers registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;FulfillmentCenter&gt;</returns>
        List<FulfillmentCenter> CommerceGetFulfillmentCenters();

        /// <summary>
        /// Return all fulfillment centers registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;FulfillmentCenter&gt;</returns>
        ApiResponse<List<FulfillmentCenter>> CommerceGetFulfillmentCentersWithHttpInfo();
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="objectId"></param>
        /// <param name="objectType"></param>
        /// <returns>List&lt;SeoInfo&gt;</returns>
        List<SeoInfo> CommerceGetSeoDuplicates(string objectId, string objectType);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="objectId"></param>
        /// <param name="objectType"></param>
        /// <returns>ApiResponse of List&lt;SeoInfo&gt;</returns>
        ApiResponse<List<SeoInfo>> CommerceGetSeoDuplicatesWithHttpInfo(string objectId, string objectType);
        /// <summary>
        /// Find all SEO records for object by slug
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">slug</param>
        /// <returns>List&lt;SeoInfo&gt;</returns>
        List<SeoInfo> CommerceGetSeoInfoBySlug(string slug);

        /// <summary>
        /// Find all SEO records for object by slug
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">slug</param>
        /// <returns>ApiResponse of List&lt;SeoInfo&gt;</returns>
        ApiResponse<List<SeoInfo>> CommerceGetSeoInfoBySlugWithHttpInfo(string slug);
        /// <summary>
        /// Payment callback operation used by external payment services to inform post process payment in our system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="callback">payment callback parameters</param>
        /// <returns>PostProcessPaymentResult</returns>
        PostProcessPaymentResult CommercePostProcessPayment(PaymentCallbackParameters callback);

        /// <summary>
        /// Payment callback operation used by external payment services to inform post process payment in our system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="callback">payment callback parameters</param>
        /// <returns>ApiResponse of PostProcessPaymentResult</returns>
        ApiResponse<PostProcessPaymentResult> CommercePostProcessPaymentWithHttpInfo(PaymentCallbackParameters callback);
        /// <summary>
        /// Update a existing currency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns></returns>
        void CommerceUpdateCurrency(Currency currency);

        /// <summary>
        /// Update a existing currency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CommerceUpdateCurrencyWithHttpInfo(Currency currency);
        /// <summary>
        /// Update a existing fulfillment center
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="center">fulfillment center</param>
        /// <returns>FulfillmentCenter</returns>
        FulfillmentCenter CommerceUpdateFulfillmentCenter(FulfillmentCenter center);

        /// <summary>
        /// Update a existing fulfillment center
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="center">fulfillment center</param>
        /// <returns>ApiResponse of FulfillmentCenter</returns>
        ApiResponse<FulfillmentCenter> CommerceUpdateFulfillmentCenterWithHttpInfo(FulfillmentCenter center);
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="user"></param>
        /// <returns>SecurityResult</returns>
        SecurityResult StorefrontSecurityCreate(ApplicationUserExtended user);

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="user"></param>
        /// <returns>ApiResponse of SecurityResult</returns>
        ApiResponse<SecurityResult> StorefrontSecurityCreateWithHttpInfo(ApplicationUserExtended user);
        /// <summary>
        /// Generate a password reset token
        /// </summary>
        /// <remarks>
        /// Generates a password reset token and sends a password reset link to the user via email.
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="storeName"></param>
        /// <param name="language"></param>
        /// <param name="callbackUrl"></param>
        /// <returns></returns>
        void StorefrontSecurityGenerateResetPasswordToken(string userId, string storeName, string language, string callbackUrl);

        /// <summary>
        /// Generate a password reset token
        /// </summary>
        /// <remarks>
        /// Generates a password reset token and sends a password reset link to the user via email.
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="storeName"></param>
        /// <param name="language"></param>
        /// <param name="callbackUrl"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> StorefrontSecurityGenerateResetPasswordTokenWithHttpInfo(string userId, string storeName, string language, string callbackUrl);
        /// <summary>
        /// Get user details by user ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <returns>StorefrontUser</returns>
        StorefrontUser StorefrontSecurityGetUserById(string userId);

        /// <summary>
        /// Get user details by user ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <returns>ApiResponse of StorefrontUser</returns>
        ApiResponse<StorefrontUser> StorefrontSecurityGetUserByIdWithHttpInfo(string userId);
        /// <summary>
        /// Get user details by external login provider
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns>StorefrontUser</returns>
        StorefrontUser StorefrontSecurityGetUserByLogin(string loginProvider, string providerKey);

        /// <summary>
        /// Get user details by external login provider
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns>ApiResponse of StorefrontUser</returns>
        ApiResponse<StorefrontUser> StorefrontSecurityGetUserByLoginWithHttpInfo(string loginProvider, string providerKey);
        /// <summary>
        /// Get user details by user name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <returns>StorefrontUser</returns>
        StorefrontUser StorefrontSecurityGetUserByName(string userName);

        /// <summary>
        /// Get user details by user name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <returns>ApiResponse of StorefrontUser</returns>
        ApiResponse<StorefrontUser> StorefrontSecurityGetUserByNameWithHttpInfo(string userName);
        /// <summary>
        /// Sign in with user name and password
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>SignInResult</returns>
        SignInResult StorefrontSecurityPasswordSignIn(string userName, string password);

        /// <summary>
        /// Sign in with user name and password
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>ApiResponse of SignInResult</returns>
        ApiResponse<SignInResult> StorefrontSecurityPasswordSignInWithHttpInfo(string userName, string password);
        /// <summary>
        /// Reset a password for the user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <returns>SecurityResult</returns>
        SecurityResult StorefrontSecurityResetPassword(string userId, string token, string newPassword);

        /// <summary>
        /// Reset a password for the user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <returns>ApiResponse of SecurityResult</returns>
        ApiResponse<SecurityResult> StorefrontSecurityResetPasswordWithHttpInfo(string userId, string token, string newPassword);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Batch create or update seo infos
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="seoInfos"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CommerceBatchUpdateSeoInfosAsync(List<SeoInfo> seoInfos);

        /// <summary>
        /// Batch create or update seo infos
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="seoInfos"></param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<object>> CommerceBatchUpdateSeoInfosAsyncWithHttpInfo(List<SeoInfo> seoInfos);
        /// <summary>
        /// Create new currency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CommerceCreateCurrencyAsync(Currency currency);

        /// <summary>
        /// Create new currency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<object>> CommerceCreateCurrencyAsyncWithHttpInfo(Currency currency);
        /// <summary>
        /// Delete currencies
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="codes">currency codes</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CommerceDeleteCurrenciesAsync(List<string> codes);

        /// <summary>
        /// Delete currencies
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="codes">currency codes</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<object>> CommerceDeleteCurrenciesAsyncWithHttpInfo(List<string> codes);
        /// <summary>
        /// Delete  fulfillment centers registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ids"></param>
        /// <returns>Task of List&lt;FulfillmentCenter&gt;</returns>
        System.Threading.Tasks.Task<List<FulfillmentCenter>> CommerceDeleteFulfillmentCentersAsync(List<string> ids);

        /// <summary>
        /// Delete  fulfillment centers registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ids"></param>
        /// <returns>Task of ApiResponse (List&lt;FulfillmentCenter&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<FulfillmentCenter>>> CommerceDeleteFulfillmentCentersAsyncWithHttpInfo(List<string> ids);
        /// <summary>
        /// Evaluate and return all tax rates for specified store and evaluation context
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="storeId"></param>
        /// <param name="evalContext"></param>
        /// <returns>Task of List&lt;TaxRate&gt;</returns>
        System.Threading.Tasks.Task<List<TaxRate>> CommerceEvaluateTaxesAsync(string storeId, TaxEvaluationContext evalContext);

        /// <summary>
        /// Evaluate and return all tax rates for specified store and evaluation context
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="storeId"></param>
        /// <param name="evalContext"></param>
        /// <returns>Task of ApiResponse (List&lt;TaxRate&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<TaxRate>>> CommerceEvaluateTaxesAsyncWithHttpInfo(string storeId, TaxEvaluationContext evalContext);
        /// <summary>
        /// Return all currencies registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;Currency&gt;</returns>
        System.Threading.Tasks.Task<List<Currency>> CommerceGetAllCurrenciesAsync();

        /// <summary>
        /// Return all currencies registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;Currency&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Currency>>> CommerceGetAllCurrenciesAsyncWithHttpInfo();
        /// <summary>
        /// Find fulfillment center by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">fulfillment center id</param>
        /// <returns>Task of FulfillmentCenter</returns>
        System.Threading.Tasks.Task<FulfillmentCenter> CommerceGetFulfillmentCenterAsync(string id);

        /// <summary>
        /// Find fulfillment center by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">fulfillment center id</param>
        /// <returns>Task of ApiResponse (FulfillmentCenter)</returns>
        System.Threading.Tasks.Task<ApiResponse<FulfillmentCenter>> CommerceGetFulfillmentCenterAsyncWithHttpInfo(string id);
        /// <summary>
        /// Return all fulfillment centers registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;FulfillmentCenter&gt;</returns>
        System.Threading.Tasks.Task<List<FulfillmentCenter>> CommerceGetFulfillmentCentersAsync();

        /// <summary>
        /// Return all fulfillment centers registered in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;FulfillmentCenter&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<FulfillmentCenter>>> CommerceGetFulfillmentCentersAsyncWithHttpInfo();
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="objectId"></param>
        /// <param name="objectType"></param>
        /// <returns>Task of List&lt;SeoInfo&gt;</returns>
        System.Threading.Tasks.Task<List<SeoInfo>> CommerceGetSeoDuplicatesAsync(string objectId, string objectType);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="objectId"></param>
        /// <param name="objectType"></param>
        /// <returns>Task of ApiResponse (List&lt;SeoInfo&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<SeoInfo>>> CommerceGetSeoDuplicatesAsyncWithHttpInfo(string objectId, string objectType);
        /// <summary>
        /// Find all SEO records for object by slug
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">slug</param>
        /// <returns>Task of List&lt;SeoInfo&gt;</returns>
        System.Threading.Tasks.Task<List<SeoInfo>> CommerceGetSeoInfoBySlugAsync(string slug);

        /// <summary>
        /// Find all SEO records for object by slug
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">slug</param>
        /// <returns>Task of ApiResponse (List&lt;SeoInfo&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<SeoInfo>>> CommerceGetSeoInfoBySlugAsyncWithHttpInfo(string slug);
        /// <summary>
        /// Payment callback operation used by external payment services to inform post process payment in our system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="callback">payment callback parameters</param>
        /// <returns>Task of PostProcessPaymentResult</returns>
        System.Threading.Tasks.Task<PostProcessPaymentResult> CommercePostProcessPaymentAsync(PaymentCallbackParameters callback);

        /// <summary>
        /// Payment callback operation used by external payment services to inform post process payment in our system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="callback">payment callback parameters</param>
        /// <returns>Task of ApiResponse (PostProcessPaymentResult)</returns>
        System.Threading.Tasks.Task<ApiResponse<PostProcessPaymentResult>> CommercePostProcessPaymentAsyncWithHttpInfo(PaymentCallbackParameters callback);
        /// <summary>
        /// Update a existing currency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CommerceUpdateCurrencyAsync(Currency currency);

        /// <summary>
        /// Update a existing currency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<object>> CommerceUpdateCurrencyAsyncWithHttpInfo(Currency currency);
        /// <summary>
        /// Update a existing fulfillment center
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="center">fulfillment center</param>
        /// <returns>Task of FulfillmentCenter</returns>
        System.Threading.Tasks.Task<FulfillmentCenter> CommerceUpdateFulfillmentCenterAsync(FulfillmentCenter center);

        /// <summary>
        /// Update a existing fulfillment center
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="center">fulfillment center</param>
        /// <returns>Task of ApiResponse (FulfillmentCenter)</returns>
        System.Threading.Tasks.Task<ApiResponse<FulfillmentCenter>> CommerceUpdateFulfillmentCenterAsyncWithHttpInfo(FulfillmentCenter center);
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="user"></param>
        /// <returns>Task of SecurityResult</returns>
        System.Threading.Tasks.Task<SecurityResult> StorefrontSecurityCreateAsync(ApplicationUserExtended user);

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="user"></param>
        /// <returns>Task of ApiResponse (SecurityResult)</returns>
        System.Threading.Tasks.Task<ApiResponse<SecurityResult>> StorefrontSecurityCreateAsyncWithHttpInfo(ApplicationUserExtended user);
        /// <summary>
        /// Generate a password reset token
        /// </summary>
        /// <remarks>
        /// Generates a password reset token and sends a password reset link to the user via email.
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="storeName"></param>
        /// <param name="language"></param>
        /// <param name="callbackUrl"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task StorefrontSecurityGenerateResetPasswordTokenAsync(string userId, string storeName, string language, string callbackUrl);

        /// <summary>
        /// Generate a password reset token
        /// </summary>
        /// <remarks>
        /// Generates a password reset token and sends a password reset link to the user via email.
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="storeName"></param>
        /// <param name="language"></param>
        /// <param name="callbackUrl"></param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<object>> StorefrontSecurityGenerateResetPasswordTokenAsyncWithHttpInfo(string userId, string storeName, string language, string callbackUrl);
        /// <summary>
        /// Get user details by user ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <returns>Task of StorefrontUser</returns>
        System.Threading.Tasks.Task<StorefrontUser> StorefrontSecurityGetUserByIdAsync(string userId);

        /// <summary>
        /// Get user details by user ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <returns>Task of ApiResponse (StorefrontUser)</returns>
        System.Threading.Tasks.Task<ApiResponse<StorefrontUser>> StorefrontSecurityGetUserByIdAsyncWithHttpInfo(string userId);
        /// <summary>
        /// Get user details by external login provider
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns>Task of StorefrontUser</returns>
        System.Threading.Tasks.Task<StorefrontUser> StorefrontSecurityGetUserByLoginAsync(string loginProvider, string providerKey);

        /// <summary>
        /// Get user details by external login provider
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns>Task of ApiResponse (StorefrontUser)</returns>
        System.Threading.Tasks.Task<ApiResponse<StorefrontUser>> StorefrontSecurityGetUserByLoginAsyncWithHttpInfo(string loginProvider, string providerKey);
        /// <summary>
        /// Get user details by user name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <returns>Task of StorefrontUser</returns>
        System.Threading.Tasks.Task<StorefrontUser> StorefrontSecurityGetUserByNameAsync(string userName);

        /// <summary>
        /// Get user details by user name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <returns>Task of ApiResponse (StorefrontUser)</returns>
        System.Threading.Tasks.Task<ApiResponse<StorefrontUser>> StorefrontSecurityGetUserByNameAsyncWithHttpInfo(string userName);
        /// <summary>
        /// Sign in with user name and password
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Task of SignInResult</returns>
        System.Threading.Tasks.Task<SignInResult> StorefrontSecurityPasswordSignInAsync(string userName, string password);

        /// <summary>
        /// Sign in with user name and password
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Task of ApiResponse (SignInResult)</returns>
        System.Threading.Tasks.Task<ApiResponse<SignInResult>> StorefrontSecurityPasswordSignInAsyncWithHttpInfo(string userName, string password);
        /// <summary>
        /// Reset a password for the user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <returns>Task of SecurityResult</returns>
        System.Threading.Tasks.Task<SecurityResult> StorefrontSecurityResetPasswordAsync(string userId, string token, string newPassword);

        /// <summary>
        /// Reset a password for the user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <returns>Task of ApiResponse (SecurityResult)</returns>
        System.Threading.Tasks.Task<ApiResponse<SecurityResult>> StorefrontSecurityResetPasswordAsyncWithHttpInfo(string userId, string token, string newPassword);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class VirtoCommerceCoreApi : IVirtoCommerceCoreApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtoCommerceCoreApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="apiClient">An instance of ApiClient.</param>
        /// <returns></returns>
        public VirtoCommerceCoreApi(ApiClient apiClient)
        {
            ApiClient = apiClient;
            Configuration = apiClient.Configuration;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Gets or sets the API client object
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Batch create or update seo infos 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="seoInfos"></param>
        /// <returns></returns>
        public void CommerceBatchUpdateSeoInfos(List<SeoInfo> seoInfos)
        {
             CommerceBatchUpdateSeoInfosWithHttpInfo(seoInfos);
        }

        /// <summary>
        /// Batch create or update seo infos 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="seoInfos"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> CommerceBatchUpdateSeoInfosWithHttpInfo(List<SeoInfo> seoInfos)
        {
            // verify the required parameter 'seoInfos' is set
            if (seoInfos == null)
                throw new ApiException(400, "Missing required parameter 'seoInfos' when calling VirtoCommerceCoreApi->CommerceBatchUpdateSeoInfos");

            var localVarPath = "/api/seoinfos/batchupdate";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (seoInfos.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(seoInfos); // http body (model) parameter
            }
            else
            {
                localVarPostBody = seoInfos; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceBatchUpdateSeoInfos: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceBatchUpdateSeoInfos: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Batch create or update seo infos 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="seoInfos"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CommerceBatchUpdateSeoInfosAsync(List<SeoInfo> seoInfos)
        {
             await CommerceBatchUpdateSeoInfosAsyncWithHttpInfo(seoInfos);

        }

        /// <summary>
        /// Batch create or update seo infos 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="seoInfos"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> CommerceBatchUpdateSeoInfosAsyncWithHttpInfo(List<SeoInfo> seoInfos)
        {
            // verify the required parameter 'seoInfos' is set
            if (seoInfos == null)
                throw new ApiException(400, "Missing required parameter 'seoInfos' when calling VirtoCommerceCoreApi->CommerceBatchUpdateSeoInfos");

            var localVarPath = "/api/seoinfos/batchupdate";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (seoInfos.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(seoInfos); // http body (model) parameter
            }
            else
            {
                localVarPostBody = seoInfos; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceBatchUpdateSeoInfos: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceBatchUpdateSeoInfos: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        /// <summary>
        /// Create new currency 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns></returns>
        public void CommerceCreateCurrency(Currency currency)
        {
             CommerceCreateCurrencyWithHttpInfo(currency);
        }

        /// <summary>
        /// Create new currency 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> CommerceCreateCurrencyWithHttpInfo(Currency currency)
        {
            // verify the required parameter 'currency' is set
            if (currency == null)
                throw new ApiException(400, "Missing required parameter 'currency' when calling VirtoCommerceCoreApi->CommerceCreateCurrency");

            var localVarPath = "/api/currencies";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (currency.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(currency); // http body (model) parameter
            }
            else
            {
                localVarPostBody = currency; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceCreateCurrency: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceCreateCurrency: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Create new currency 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CommerceCreateCurrencyAsync(Currency currency)
        {
             await CommerceCreateCurrencyAsyncWithHttpInfo(currency);

        }

        /// <summary>
        /// Create new currency 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> CommerceCreateCurrencyAsyncWithHttpInfo(Currency currency)
        {
            // verify the required parameter 'currency' is set
            if (currency == null)
                throw new ApiException(400, "Missing required parameter 'currency' when calling VirtoCommerceCoreApi->CommerceCreateCurrency");

            var localVarPath = "/api/currencies";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (currency.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(currency); // http body (model) parameter
            }
            else
            {
                localVarPostBody = currency; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceCreateCurrency: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceCreateCurrency: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        /// <summary>
        /// Delete currencies 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="codes">currency codes</param>
        /// <returns></returns>
        public void CommerceDeleteCurrencies(List<string> codes)
        {
             CommerceDeleteCurrenciesWithHttpInfo(codes);
        }

        /// <summary>
        /// Delete currencies 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="codes">currency codes</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> CommerceDeleteCurrenciesWithHttpInfo(List<string> codes)
        {
            // verify the required parameter 'codes' is set
            if (codes == null)
                throw new ApiException(400, "Missing required parameter 'codes' when calling VirtoCommerceCoreApi->CommerceDeleteCurrencies");

            var localVarPath = "/api/currencies";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (codes != null) localVarQueryParams.Add("codes", ApiClient.ParameterToString(codes)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceDeleteCurrencies: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceDeleteCurrencies: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Delete currencies 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="codes">currency codes</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CommerceDeleteCurrenciesAsync(List<string> codes)
        {
             await CommerceDeleteCurrenciesAsyncWithHttpInfo(codes);

        }

        /// <summary>
        /// Delete currencies 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="codes">currency codes</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> CommerceDeleteCurrenciesAsyncWithHttpInfo(List<string> codes)
        {
            // verify the required parameter 'codes' is set
            if (codes == null)
                throw new ApiException(400, "Missing required parameter 'codes' when calling VirtoCommerceCoreApi->CommerceDeleteCurrencies");

            var localVarPath = "/api/currencies";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (codes != null) localVarQueryParams.Add("codes", ApiClient.ParameterToString(codes)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceDeleteCurrencies: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceDeleteCurrencies: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        /// <summary>
        /// Delete  fulfillment centers registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ids"></param>
        /// <returns>List&lt;FulfillmentCenter&gt;</returns>
        public List<FulfillmentCenter> CommerceDeleteFulfillmentCenters(List<string> ids)
        {
             ApiResponse<List<FulfillmentCenter>> localVarResponse = CommerceDeleteFulfillmentCentersWithHttpInfo(ids);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete  fulfillment centers registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ids"></param>
        /// <returns>ApiResponse of List&lt;FulfillmentCenter&gt;</returns>
        public ApiResponse<List<FulfillmentCenter>> CommerceDeleteFulfillmentCentersWithHttpInfo(List<string> ids)
        {
            // verify the required parameter 'ids' is set
            if (ids == null)
                throw new ApiException(400, "Missing required parameter 'ids' when calling VirtoCommerceCoreApi->CommerceDeleteFulfillmentCenters");

            var localVarPath = "/api/fulfillment/centers";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (ids != null) localVarQueryParams.Add("ids", ApiClient.ParameterToString(ids)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceDeleteFulfillmentCenters: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceDeleteFulfillmentCenters: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<FulfillmentCenter>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FulfillmentCenter>)ApiClient.Deserialize(localVarResponse, typeof(List<FulfillmentCenter>)));
            
        }

        /// <summary>
        /// Delete  fulfillment centers registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ids"></param>
        /// <returns>Task of List&lt;FulfillmentCenter&gt;</returns>
        public async System.Threading.Tasks.Task<List<FulfillmentCenter>> CommerceDeleteFulfillmentCentersAsync(List<string> ids)
        {
             ApiResponse<List<FulfillmentCenter>> localVarResponse = await CommerceDeleteFulfillmentCentersAsyncWithHttpInfo(ids);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete  fulfillment centers registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ids"></param>
        /// <returns>Task of ApiResponse (List&lt;FulfillmentCenter&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<FulfillmentCenter>>> CommerceDeleteFulfillmentCentersAsyncWithHttpInfo(List<string> ids)
        {
            // verify the required parameter 'ids' is set
            if (ids == null)
                throw new ApiException(400, "Missing required parameter 'ids' when calling VirtoCommerceCoreApi->CommerceDeleteFulfillmentCenters");

            var localVarPath = "/api/fulfillment/centers";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (ids != null) localVarQueryParams.Add("ids", ApiClient.ParameterToString(ids)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceDeleteFulfillmentCenters: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceDeleteFulfillmentCenters: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<FulfillmentCenter>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FulfillmentCenter>)ApiClient.Deserialize(localVarResponse, typeof(List<FulfillmentCenter>)));
            
        }
        /// <summary>
        /// Evaluate and return all tax rates for specified store and evaluation context 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="storeId"></param>
        /// <param name="evalContext"></param>
        /// <returns>List&lt;TaxRate&gt;</returns>
        public List<TaxRate> CommerceEvaluateTaxes(string storeId, TaxEvaluationContext evalContext)
        {
             ApiResponse<List<TaxRate>> localVarResponse = CommerceEvaluateTaxesWithHttpInfo(storeId, evalContext);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Evaluate and return all tax rates for specified store and evaluation context 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="storeId"></param>
        /// <param name="evalContext"></param>
        /// <returns>ApiResponse of List&lt;TaxRate&gt;</returns>
        public ApiResponse<List<TaxRate>> CommerceEvaluateTaxesWithHttpInfo(string storeId, TaxEvaluationContext evalContext)
        {
            // verify the required parameter 'storeId' is set
            if (storeId == null)
                throw new ApiException(400, "Missing required parameter 'storeId' when calling VirtoCommerceCoreApi->CommerceEvaluateTaxes");
            // verify the required parameter 'evalContext' is set
            if (evalContext == null)
                throw new ApiException(400, "Missing required parameter 'evalContext' when calling VirtoCommerceCoreApi->CommerceEvaluateTaxes");

            var localVarPath = "/api/taxes/{storeId}/evaluate";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (storeId != null) localVarPathParams.Add("storeId", ApiClient.ParameterToString(storeId)); // path parameter
            if (evalContext.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(evalContext); // http body (model) parameter
            }
            else
            {
                localVarPostBody = evalContext; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceEvaluateTaxes: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceEvaluateTaxes: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<TaxRate>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<TaxRate>)ApiClient.Deserialize(localVarResponse, typeof(List<TaxRate>)));
            
        }

        /// <summary>
        /// Evaluate and return all tax rates for specified store and evaluation context 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="storeId"></param>
        /// <param name="evalContext"></param>
        /// <returns>Task of List&lt;TaxRate&gt;</returns>
        public async System.Threading.Tasks.Task<List<TaxRate>> CommerceEvaluateTaxesAsync(string storeId, TaxEvaluationContext evalContext)
        {
             ApiResponse<List<TaxRate>> localVarResponse = await CommerceEvaluateTaxesAsyncWithHttpInfo(storeId, evalContext);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Evaluate and return all tax rates for specified store and evaluation context 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="storeId"></param>
        /// <param name="evalContext"></param>
        /// <returns>Task of ApiResponse (List&lt;TaxRate&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<TaxRate>>> CommerceEvaluateTaxesAsyncWithHttpInfo(string storeId, TaxEvaluationContext evalContext)
        {
            // verify the required parameter 'storeId' is set
            if (storeId == null)
                throw new ApiException(400, "Missing required parameter 'storeId' when calling VirtoCommerceCoreApi->CommerceEvaluateTaxes");
            // verify the required parameter 'evalContext' is set
            if (evalContext == null)
                throw new ApiException(400, "Missing required parameter 'evalContext' when calling VirtoCommerceCoreApi->CommerceEvaluateTaxes");

            var localVarPath = "/api/taxes/{storeId}/evaluate";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (storeId != null) localVarPathParams.Add("storeId", ApiClient.ParameterToString(storeId)); // path parameter
            if (evalContext.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(evalContext); // http body (model) parameter
            }
            else
            {
                localVarPostBody = evalContext; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceEvaluateTaxes: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceEvaluateTaxes: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<TaxRate>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<TaxRate>)ApiClient.Deserialize(localVarResponse, typeof(List<TaxRate>)));
            
        }
        /// <summary>
        /// Return all currencies registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Currency&gt;</returns>
        public List<Currency> CommerceGetAllCurrencies()
        {
             ApiResponse<List<Currency>> localVarResponse = CommerceGetAllCurrenciesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Return all currencies registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Currency&gt;</returns>
        public ApiResponse<List<Currency>> CommerceGetAllCurrenciesWithHttpInfo()
        {

            var localVarPath = "/api/currencies";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetAllCurrencies: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetAllCurrencies: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<Currency>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Currency>)ApiClient.Deserialize(localVarResponse, typeof(List<Currency>)));
            
        }

        /// <summary>
        /// Return all currencies registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;Currency&gt;</returns>
        public async System.Threading.Tasks.Task<List<Currency>> CommerceGetAllCurrenciesAsync()
        {
             ApiResponse<List<Currency>> localVarResponse = await CommerceGetAllCurrenciesAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Return all currencies registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;Currency&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Currency>>> CommerceGetAllCurrenciesAsyncWithHttpInfo()
        {

            var localVarPath = "/api/currencies";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetAllCurrencies: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetAllCurrencies: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<Currency>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Currency>)ApiClient.Deserialize(localVarResponse, typeof(List<Currency>)));
            
        }
        /// <summary>
        /// Find fulfillment center by id 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">fulfillment center id</param>
        /// <returns>FulfillmentCenter</returns>
        public FulfillmentCenter CommerceGetFulfillmentCenter(string id)
        {
             ApiResponse<FulfillmentCenter> localVarResponse = CommerceGetFulfillmentCenterWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Find fulfillment center by id 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">fulfillment center id</param>
        /// <returns>ApiResponse of FulfillmentCenter</returns>
        public ApiResponse<FulfillmentCenter> CommerceGetFulfillmentCenterWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling VirtoCommerceCoreApi->CommerceGetFulfillmentCenter");

            var localVarPath = "/api/fulfillment/centers/{id}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (id != null) localVarPathParams.Add("id", ApiClient.ParameterToString(id)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetFulfillmentCenter: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetFulfillmentCenter: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<FulfillmentCenter>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FulfillmentCenter)ApiClient.Deserialize(localVarResponse, typeof(FulfillmentCenter)));
            
        }

        /// <summary>
        /// Find fulfillment center by id 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">fulfillment center id</param>
        /// <returns>Task of FulfillmentCenter</returns>
        public async System.Threading.Tasks.Task<FulfillmentCenter> CommerceGetFulfillmentCenterAsync(string id)
        {
             ApiResponse<FulfillmentCenter> localVarResponse = await CommerceGetFulfillmentCenterAsyncWithHttpInfo(id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Find fulfillment center by id 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">fulfillment center id</param>
        /// <returns>Task of ApiResponse (FulfillmentCenter)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<FulfillmentCenter>> CommerceGetFulfillmentCenterAsyncWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling VirtoCommerceCoreApi->CommerceGetFulfillmentCenter");

            var localVarPath = "/api/fulfillment/centers/{id}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (id != null) localVarPathParams.Add("id", ApiClient.ParameterToString(id)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetFulfillmentCenter: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetFulfillmentCenter: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<FulfillmentCenter>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FulfillmentCenter)ApiClient.Deserialize(localVarResponse, typeof(FulfillmentCenter)));
            
        }
        /// <summary>
        /// Return all fulfillment centers registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;FulfillmentCenter&gt;</returns>
        public List<FulfillmentCenter> CommerceGetFulfillmentCenters()
        {
             ApiResponse<List<FulfillmentCenter>> localVarResponse = CommerceGetFulfillmentCentersWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Return all fulfillment centers registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;FulfillmentCenter&gt;</returns>
        public ApiResponse<List<FulfillmentCenter>> CommerceGetFulfillmentCentersWithHttpInfo()
        {

            var localVarPath = "/api/fulfillment/centers";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetFulfillmentCenters: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetFulfillmentCenters: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<FulfillmentCenter>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FulfillmentCenter>)ApiClient.Deserialize(localVarResponse, typeof(List<FulfillmentCenter>)));
            
        }

        /// <summary>
        /// Return all fulfillment centers registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;FulfillmentCenter&gt;</returns>
        public async System.Threading.Tasks.Task<List<FulfillmentCenter>> CommerceGetFulfillmentCentersAsync()
        {
             ApiResponse<List<FulfillmentCenter>> localVarResponse = await CommerceGetFulfillmentCentersAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Return all fulfillment centers registered in the system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;FulfillmentCenter&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<FulfillmentCenter>>> CommerceGetFulfillmentCentersAsyncWithHttpInfo()
        {

            var localVarPath = "/api/fulfillment/centers";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetFulfillmentCenters: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetFulfillmentCenters: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<FulfillmentCenter>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FulfillmentCenter>)ApiClient.Deserialize(localVarResponse, typeof(List<FulfillmentCenter>)));
            
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="objectId"></param>
        /// <param name="objectType"></param>
        /// <returns>List&lt;SeoInfo&gt;</returns>
        public List<SeoInfo> CommerceGetSeoDuplicates(string objectId, string objectType)
        {
             ApiResponse<List<SeoInfo>> localVarResponse = CommerceGetSeoDuplicatesWithHttpInfo(objectId, objectType);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="objectId"></param>
        /// <param name="objectType"></param>
        /// <returns>ApiResponse of List&lt;SeoInfo&gt;</returns>
        public ApiResponse<List<SeoInfo>> CommerceGetSeoDuplicatesWithHttpInfo(string objectId, string objectType)
        {
            // verify the required parameter 'objectId' is set
            if (objectId == null)
                throw new ApiException(400, "Missing required parameter 'objectId' when calling VirtoCommerceCoreApi->CommerceGetSeoDuplicates");
            // verify the required parameter 'objectType' is set
            if (objectType == null)
                throw new ApiException(400, "Missing required parameter 'objectType' when calling VirtoCommerceCoreApi->CommerceGetSeoDuplicates");

            var localVarPath = "/api/seoinfos/duplicates";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (objectId != null) localVarQueryParams.Add("objectId", ApiClient.ParameterToString(objectId)); // query parameter
            if (objectType != null) localVarQueryParams.Add("objectType", ApiClient.ParameterToString(objectType)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetSeoDuplicates: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetSeoDuplicates: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<SeoInfo>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SeoInfo>)ApiClient.Deserialize(localVarResponse, typeof(List<SeoInfo>)));
            
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="objectId"></param>
        /// <param name="objectType"></param>
        /// <returns>Task of List&lt;SeoInfo&gt;</returns>
        public async System.Threading.Tasks.Task<List<SeoInfo>> CommerceGetSeoDuplicatesAsync(string objectId, string objectType)
        {
             ApiResponse<List<SeoInfo>> localVarResponse = await CommerceGetSeoDuplicatesAsyncWithHttpInfo(objectId, objectType);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="objectId"></param>
        /// <param name="objectType"></param>
        /// <returns>Task of ApiResponse (List&lt;SeoInfo&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<SeoInfo>>> CommerceGetSeoDuplicatesAsyncWithHttpInfo(string objectId, string objectType)
        {
            // verify the required parameter 'objectId' is set
            if (objectId == null)
                throw new ApiException(400, "Missing required parameter 'objectId' when calling VirtoCommerceCoreApi->CommerceGetSeoDuplicates");
            // verify the required parameter 'objectType' is set
            if (objectType == null)
                throw new ApiException(400, "Missing required parameter 'objectType' when calling VirtoCommerceCoreApi->CommerceGetSeoDuplicates");

            var localVarPath = "/api/seoinfos/duplicates";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (objectId != null) localVarQueryParams.Add("objectId", ApiClient.ParameterToString(objectId)); // query parameter
            if (objectType != null) localVarQueryParams.Add("objectType", ApiClient.ParameterToString(objectType)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetSeoDuplicates: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetSeoDuplicates: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<SeoInfo>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SeoInfo>)ApiClient.Deserialize(localVarResponse, typeof(List<SeoInfo>)));
            
        }
        /// <summary>
        /// Find all SEO records for object by slug 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">slug</param>
        /// <returns>List&lt;SeoInfo&gt;</returns>
        public List<SeoInfo> CommerceGetSeoInfoBySlug(string slug)
        {
             ApiResponse<List<SeoInfo>> localVarResponse = CommerceGetSeoInfoBySlugWithHttpInfo(slug);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Find all SEO records for object by slug 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">slug</param>
        /// <returns>ApiResponse of List&lt;SeoInfo&gt;</returns>
        public ApiResponse<List<SeoInfo>> CommerceGetSeoInfoBySlugWithHttpInfo(string slug)
        {
            // verify the required parameter 'slug' is set
            if (slug == null)
                throw new ApiException(400, "Missing required parameter 'slug' when calling VirtoCommerceCoreApi->CommerceGetSeoInfoBySlug");

            var localVarPath = "/api/seoinfos/{slug}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (slug != null) localVarPathParams.Add("slug", ApiClient.ParameterToString(slug)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetSeoInfoBySlug: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetSeoInfoBySlug: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<SeoInfo>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SeoInfo>)ApiClient.Deserialize(localVarResponse, typeof(List<SeoInfo>)));
            
        }

        /// <summary>
        /// Find all SEO records for object by slug 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">slug</param>
        /// <returns>Task of List&lt;SeoInfo&gt;</returns>
        public async System.Threading.Tasks.Task<List<SeoInfo>> CommerceGetSeoInfoBySlugAsync(string slug)
        {
             ApiResponse<List<SeoInfo>> localVarResponse = await CommerceGetSeoInfoBySlugAsyncWithHttpInfo(slug);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Find all SEO records for object by slug 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="slug">slug</param>
        /// <returns>Task of ApiResponse (List&lt;SeoInfo&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<SeoInfo>>> CommerceGetSeoInfoBySlugAsyncWithHttpInfo(string slug)
        {
            // verify the required parameter 'slug' is set
            if (slug == null)
                throw new ApiException(400, "Missing required parameter 'slug' when calling VirtoCommerceCoreApi->CommerceGetSeoInfoBySlug");

            var localVarPath = "/api/seoinfos/{slug}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (slug != null) localVarPathParams.Add("slug", ApiClient.ParameterToString(slug)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetSeoInfoBySlug: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceGetSeoInfoBySlug: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<SeoInfo>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<SeoInfo>)ApiClient.Deserialize(localVarResponse, typeof(List<SeoInfo>)));
            
        }
        /// <summary>
        /// Payment callback operation used by external payment services to inform post process payment in our system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="callback">payment callback parameters</param>
        /// <returns>PostProcessPaymentResult</returns>
        public PostProcessPaymentResult CommercePostProcessPayment(PaymentCallbackParameters callback)
        {
             ApiResponse<PostProcessPaymentResult> localVarResponse = CommercePostProcessPaymentWithHttpInfo(callback);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Payment callback operation used by external payment services to inform post process payment in our system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="callback">payment callback parameters</param>
        /// <returns>ApiResponse of PostProcessPaymentResult</returns>
        public ApiResponse<PostProcessPaymentResult> CommercePostProcessPaymentWithHttpInfo(PaymentCallbackParameters callback)
        {
            // verify the required parameter 'callback' is set
            if (callback == null)
                throw new ApiException(400, "Missing required parameter 'callback' when calling VirtoCommerceCoreApi->CommercePostProcessPayment");

            var localVarPath = "/api/paymentcallback";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (callback.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(callback); // http body (model) parameter
            }
            else
            {
                localVarPostBody = callback; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommercePostProcessPayment: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommercePostProcessPayment: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<PostProcessPaymentResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PostProcessPaymentResult)ApiClient.Deserialize(localVarResponse, typeof(PostProcessPaymentResult)));
            
        }

        /// <summary>
        /// Payment callback operation used by external payment services to inform post process payment in our system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="callback">payment callback parameters</param>
        /// <returns>Task of PostProcessPaymentResult</returns>
        public async System.Threading.Tasks.Task<PostProcessPaymentResult> CommercePostProcessPaymentAsync(PaymentCallbackParameters callback)
        {
             ApiResponse<PostProcessPaymentResult> localVarResponse = await CommercePostProcessPaymentAsyncWithHttpInfo(callback);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Payment callback operation used by external payment services to inform post process payment in our system 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="callback">payment callback parameters</param>
        /// <returns>Task of ApiResponse (PostProcessPaymentResult)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PostProcessPaymentResult>> CommercePostProcessPaymentAsyncWithHttpInfo(PaymentCallbackParameters callback)
        {
            // verify the required parameter 'callback' is set
            if (callback == null)
                throw new ApiException(400, "Missing required parameter 'callback' when calling VirtoCommerceCoreApi->CommercePostProcessPayment");

            var localVarPath = "/api/paymentcallback";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (callback.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(callback); // http body (model) parameter
            }
            else
            {
                localVarPostBody = callback; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommercePostProcessPayment: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommercePostProcessPayment: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<PostProcessPaymentResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PostProcessPaymentResult)ApiClient.Deserialize(localVarResponse, typeof(PostProcessPaymentResult)));
            
        }
        /// <summary>
        /// Update a existing currency 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns></returns>
        public void CommerceUpdateCurrency(Currency currency)
        {
             CommerceUpdateCurrencyWithHttpInfo(currency);
        }

        /// <summary>
        /// Update a existing currency 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> CommerceUpdateCurrencyWithHttpInfo(Currency currency)
        {
            // verify the required parameter 'currency' is set
            if (currency == null)
                throw new ApiException(400, "Missing required parameter 'currency' when calling VirtoCommerceCoreApi->CommerceUpdateCurrency");

            var localVarPath = "/api/currencies";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (currency.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(currency); // http body (model) parameter
            }
            else
            {
                localVarPostBody = currency; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceUpdateCurrency: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceUpdateCurrency: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Update a existing currency 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CommerceUpdateCurrencyAsync(Currency currency)
        {
             await CommerceUpdateCurrencyAsyncWithHttpInfo(currency);

        }

        /// <summary>
        /// Update a existing currency 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">currency</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> CommerceUpdateCurrencyAsyncWithHttpInfo(Currency currency)
        {
            // verify the required parameter 'currency' is set
            if (currency == null)
                throw new ApiException(400, "Missing required parameter 'currency' when calling VirtoCommerceCoreApi->CommerceUpdateCurrency");

            var localVarPath = "/api/currencies";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (currency.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(currency); // http body (model) parameter
            }
            else
            {
                localVarPostBody = currency; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceUpdateCurrency: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceUpdateCurrency: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        /// <summary>
        /// Update a existing fulfillment center 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="center">fulfillment center</param>
        /// <returns>FulfillmentCenter</returns>
        public FulfillmentCenter CommerceUpdateFulfillmentCenter(FulfillmentCenter center)
        {
             ApiResponse<FulfillmentCenter> localVarResponse = CommerceUpdateFulfillmentCenterWithHttpInfo(center);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update a existing fulfillment center 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="center">fulfillment center</param>
        /// <returns>ApiResponse of FulfillmentCenter</returns>
        public ApiResponse<FulfillmentCenter> CommerceUpdateFulfillmentCenterWithHttpInfo(FulfillmentCenter center)
        {
            // verify the required parameter 'center' is set
            if (center == null)
                throw new ApiException(400, "Missing required parameter 'center' when calling VirtoCommerceCoreApi->CommerceUpdateFulfillmentCenter");

            var localVarPath = "/api/fulfillment/centers";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (center.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(center); // http body (model) parameter
            }
            else
            {
                localVarPostBody = center; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceUpdateFulfillmentCenter: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceUpdateFulfillmentCenter: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<FulfillmentCenter>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FulfillmentCenter)ApiClient.Deserialize(localVarResponse, typeof(FulfillmentCenter)));
            
        }

        /// <summary>
        /// Update a existing fulfillment center 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="center">fulfillment center</param>
        /// <returns>Task of FulfillmentCenter</returns>
        public async System.Threading.Tasks.Task<FulfillmentCenter> CommerceUpdateFulfillmentCenterAsync(FulfillmentCenter center)
        {
             ApiResponse<FulfillmentCenter> localVarResponse = await CommerceUpdateFulfillmentCenterAsyncWithHttpInfo(center);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update a existing fulfillment center 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="center">fulfillment center</param>
        /// <returns>Task of ApiResponse (FulfillmentCenter)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<FulfillmentCenter>> CommerceUpdateFulfillmentCenterAsyncWithHttpInfo(FulfillmentCenter center)
        {
            // verify the required parameter 'center' is set
            if (center == null)
                throw new ApiException(400, "Missing required parameter 'center' when calling VirtoCommerceCoreApi->CommerceUpdateFulfillmentCenter");

            var localVarPath = "/api/fulfillment/centers";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (center.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(center); // http body (model) parameter
            }
            else
            {
                localVarPostBody = center; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling CommerceUpdateFulfillmentCenter: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling CommerceUpdateFulfillmentCenter: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<FulfillmentCenter>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FulfillmentCenter)ApiClient.Deserialize(localVarResponse, typeof(FulfillmentCenter)));
            
        }
        /// <summary>
        /// Create a new user 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="user"></param>
        /// <returns>SecurityResult</returns>
        public SecurityResult StorefrontSecurityCreate(ApplicationUserExtended user)
        {
             ApiResponse<SecurityResult> localVarResponse = StorefrontSecurityCreateWithHttpInfo(user);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new user 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="user"></param>
        /// <returns>ApiResponse of SecurityResult</returns>
        public ApiResponse<SecurityResult> StorefrontSecurityCreateWithHttpInfo(ApplicationUserExtended user)
        {
            // verify the required parameter 'user' is set
            if (user == null)
                throw new ApiException(400, "Missing required parameter 'user' when calling VirtoCommerceCoreApi->StorefrontSecurityCreate");

            var localVarPath = "/api/storefront/security/user";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (user.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(user); // http body (model) parameter
            }
            else
            {
                localVarPostBody = user; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityCreate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityCreate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<SecurityResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SecurityResult)ApiClient.Deserialize(localVarResponse, typeof(SecurityResult)));
            
        }

        /// <summary>
        /// Create a new user 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="user"></param>
        /// <returns>Task of SecurityResult</returns>
        public async System.Threading.Tasks.Task<SecurityResult> StorefrontSecurityCreateAsync(ApplicationUserExtended user)
        {
             ApiResponse<SecurityResult> localVarResponse = await StorefrontSecurityCreateAsyncWithHttpInfo(user);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a new user 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="user"></param>
        /// <returns>Task of ApiResponse (SecurityResult)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<SecurityResult>> StorefrontSecurityCreateAsyncWithHttpInfo(ApplicationUserExtended user)
        {
            // verify the required parameter 'user' is set
            if (user == null)
                throw new ApiException(400, "Missing required parameter 'user' when calling VirtoCommerceCoreApi->StorefrontSecurityCreate");

            var localVarPath = "/api/storefront/security/user";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml", 
                "application/x-www-form-urlencoded"
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (user.GetType() != typeof(byte[]))
            {
                localVarPostBody = ApiClient.Serialize(user); // http body (model) parameter
            }
            else
            {
                localVarPostBody = user; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityCreate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityCreate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<SecurityResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SecurityResult)ApiClient.Deserialize(localVarResponse, typeof(SecurityResult)));
            
        }
        /// <summary>
        /// Generate a password reset token Generates a password reset token and sends a password reset link to the user via email.
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="storeName"></param>
        /// <param name="language"></param>
        /// <param name="callbackUrl"></param>
        /// <returns></returns>
        public void StorefrontSecurityGenerateResetPasswordToken(string userId, string storeName, string language, string callbackUrl)
        {
             StorefrontSecurityGenerateResetPasswordTokenWithHttpInfo(userId, storeName, language, callbackUrl);
        }

        /// <summary>
        /// Generate a password reset token Generates a password reset token and sends a password reset link to the user via email.
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="storeName"></param>
        /// <param name="language"></param>
        /// <param name="callbackUrl"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> StorefrontSecurityGenerateResetPasswordTokenWithHttpInfo(string userId, string storeName, string language, string callbackUrl)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling VirtoCommerceCoreApi->StorefrontSecurityGenerateResetPasswordToken");
            // verify the required parameter 'storeName' is set
            if (storeName == null)
                throw new ApiException(400, "Missing required parameter 'storeName' when calling VirtoCommerceCoreApi->StorefrontSecurityGenerateResetPasswordToken");
            // verify the required parameter 'language' is set
            if (language == null)
                throw new ApiException(400, "Missing required parameter 'language' when calling VirtoCommerceCoreApi->StorefrontSecurityGenerateResetPasswordToken");
            // verify the required parameter 'callbackUrl' is set
            if (callbackUrl == null)
                throw new ApiException(400, "Missing required parameter 'callbackUrl' when calling VirtoCommerceCoreApi->StorefrontSecurityGenerateResetPasswordToken");

            var localVarPath = "/api/storefront/security/user/password/resettoken";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (userId != null) localVarQueryParams.Add("userId", ApiClient.ParameterToString(userId)); // query parameter
            if (storeName != null) localVarQueryParams.Add("storeName", ApiClient.ParameterToString(storeName)); // query parameter
            if (language != null) localVarQueryParams.Add("language", ApiClient.ParameterToString(language)); // query parameter
            if (callbackUrl != null) localVarQueryParams.Add("callbackUrl", ApiClient.ParameterToString(callbackUrl)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGenerateResetPasswordToken: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGenerateResetPasswordToken: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Generate a password reset token Generates a password reset token and sends a password reset link to the user via email.
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="storeName"></param>
        /// <param name="language"></param>
        /// <param name="callbackUrl"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task StorefrontSecurityGenerateResetPasswordTokenAsync(string userId, string storeName, string language, string callbackUrl)
        {
             await StorefrontSecurityGenerateResetPasswordTokenAsyncWithHttpInfo(userId, storeName, language, callbackUrl);

        }

        /// <summary>
        /// Generate a password reset token Generates a password reset token and sends a password reset link to the user via email.
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="storeName"></param>
        /// <param name="language"></param>
        /// <param name="callbackUrl"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> StorefrontSecurityGenerateResetPasswordTokenAsyncWithHttpInfo(string userId, string storeName, string language, string callbackUrl)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling VirtoCommerceCoreApi->StorefrontSecurityGenerateResetPasswordToken");
            // verify the required parameter 'storeName' is set
            if (storeName == null)
                throw new ApiException(400, "Missing required parameter 'storeName' when calling VirtoCommerceCoreApi->StorefrontSecurityGenerateResetPasswordToken");
            // verify the required parameter 'language' is set
            if (language == null)
                throw new ApiException(400, "Missing required parameter 'language' when calling VirtoCommerceCoreApi->StorefrontSecurityGenerateResetPasswordToken");
            // verify the required parameter 'callbackUrl' is set
            if (callbackUrl == null)
                throw new ApiException(400, "Missing required parameter 'callbackUrl' when calling VirtoCommerceCoreApi->StorefrontSecurityGenerateResetPasswordToken");

            var localVarPath = "/api/storefront/security/user/password/resettoken";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (userId != null) localVarQueryParams.Add("userId", ApiClient.ParameterToString(userId)); // query parameter
            if (storeName != null) localVarQueryParams.Add("storeName", ApiClient.ParameterToString(storeName)); // query parameter
            if (language != null) localVarQueryParams.Add("language", ApiClient.ParameterToString(language)); // query parameter
            if (callbackUrl != null) localVarQueryParams.Add("callbackUrl", ApiClient.ParameterToString(callbackUrl)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGenerateResetPasswordToken: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGenerateResetPasswordToken: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        /// <summary>
        /// Get user details by user ID 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <returns>StorefrontUser</returns>
        public StorefrontUser StorefrontSecurityGetUserById(string userId)
        {
             ApiResponse<StorefrontUser> localVarResponse = StorefrontSecurityGetUserByIdWithHttpInfo(userId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get user details by user ID 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <returns>ApiResponse of StorefrontUser</returns>
        public ApiResponse<StorefrontUser> StorefrontSecurityGetUserByIdWithHttpInfo(string userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling VirtoCommerceCoreApi->StorefrontSecurityGetUserById");

            var localVarPath = "/api/storefront/security/user/id/{userId}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (userId != null) localVarPathParams.Add("userId", ApiClient.ParameterToString(userId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserById: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserById: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<StorefrontUser>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (StorefrontUser)ApiClient.Deserialize(localVarResponse, typeof(StorefrontUser)));
            
        }

        /// <summary>
        /// Get user details by user ID 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <returns>Task of StorefrontUser</returns>
        public async System.Threading.Tasks.Task<StorefrontUser> StorefrontSecurityGetUserByIdAsync(string userId)
        {
             ApiResponse<StorefrontUser> localVarResponse = await StorefrontSecurityGetUserByIdAsyncWithHttpInfo(userId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get user details by user ID 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <returns>Task of ApiResponse (StorefrontUser)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<StorefrontUser>> StorefrontSecurityGetUserByIdAsyncWithHttpInfo(string userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling VirtoCommerceCoreApi->StorefrontSecurityGetUserById");

            var localVarPath = "/api/storefront/security/user/id/{userId}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (userId != null) localVarPathParams.Add("userId", ApiClient.ParameterToString(userId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserById: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserById: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<StorefrontUser>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (StorefrontUser)ApiClient.Deserialize(localVarResponse, typeof(StorefrontUser)));
            
        }
        /// <summary>
        /// Get user details by external login provider 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns>StorefrontUser</returns>
        public StorefrontUser StorefrontSecurityGetUserByLogin(string loginProvider, string providerKey)
        {
             ApiResponse<StorefrontUser> localVarResponse = StorefrontSecurityGetUserByLoginWithHttpInfo(loginProvider, providerKey);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get user details by external login provider 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns>ApiResponse of StorefrontUser</returns>
        public ApiResponse<StorefrontUser> StorefrontSecurityGetUserByLoginWithHttpInfo(string loginProvider, string providerKey)
        {
            // verify the required parameter 'loginProvider' is set
            if (loginProvider == null)
                throw new ApiException(400, "Missing required parameter 'loginProvider' when calling VirtoCommerceCoreApi->StorefrontSecurityGetUserByLogin");
            // verify the required parameter 'providerKey' is set
            if (providerKey == null)
                throw new ApiException(400, "Missing required parameter 'providerKey' when calling VirtoCommerceCoreApi->StorefrontSecurityGetUserByLogin");

            var localVarPath = "/api/storefront/security/user/external";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (loginProvider != null) localVarQueryParams.Add("loginProvider", ApiClient.ParameterToString(loginProvider)); // query parameter
            if (providerKey != null) localVarQueryParams.Add("providerKey", ApiClient.ParameterToString(providerKey)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserByLogin: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserByLogin: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<StorefrontUser>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (StorefrontUser)ApiClient.Deserialize(localVarResponse, typeof(StorefrontUser)));
            
        }

        /// <summary>
        /// Get user details by external login provider 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns>Task of StorefrontUser</returns>
        public async System.Threading.Tasks.Task<StorefrontUser> StorefrontSecurityGetUserByLoginAsync(string loginProvider, string providerKey)
        {
             ApiResponse<StorefrontUser> localVarResponse = await StorefrontSecurityGetUserByLoginAsyncWithHttpInfo(loginProvider, providerKey);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get user details by external login provider 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns>Task of ApiResponse (StorefrontUser)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<StorefrontUser>> StorefrontSecurityGetUserByLoginAsyncWithHttpInfo(string loginProvider, string providerKey)
        {
            // verify the required parameter 'loginProvider' is set
            if (loginProvider == null)
                throw new ApiException(400, "Missing required parameter 'loginProvider' when calling VirtoCommerceCoreApi->StorefrontSecurityGetUserByLogin");
            // verify the required parameter 'providerKey' is set
            if (providerKey == null)
                throw new ApiException(400, "Missing required parameter 'providerKey' when calling VirtoCommerceCoreApi->StorefrontSecurityGetUserByLogin");

            var localVarPath = "/api/storefront/security/user/external";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (loginProvider != null) localVarQueryParams.Add("loginProvider", ApiClient.ParameterToString(loginProvider)); // query parameter
            if (providerKey != null) localVarQueryParams.Add("providerKey", ApiClient.ParameterToString(providerKey)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserByLogin: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserByLogin: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<StorefrontUser>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (StorefrontUser)ApiClient.Deserialize(localVarResponse, typeof(StorefrontUser)));
            
        }
        /// <summary>
        /// Get user details by user name 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <returns>StorefrontUser</returns>
        public StorefrontUser StorefrontSecurityGetUserByName(string userName)
        {
             ApiResponse<StorefrontUser> localVarResponse = StorefrontSecurityGetUserByNameWithHttpInfo(userName);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get user details by user name 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <returns>ApiResponse of StorefrontUser</returns>
        public ApiResponse<StorefrontUser> StorefrontSecurityGetUserByNameWithHttpInfo(string userName)
        {
            // verify the required parameter 'userName' is set
            if (userName == null)
                throw new ApiException(400, "Missing required parameter 'userName' when calling VirtoCommerceCoreApi->StorefrontSecurityGetUserByName");

            var localVarPath = "/api/storefront/security/user/name/{userName}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (userName != null) localVarPathParams.Add("userName", ApiClient.ParameterToString(userName)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserByName: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserByName: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<StorefrontUser>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (StorefrontUser)ApiClient.Deserialize(localVarResponse, typeof(StorefrontUser)));
            
        }

        /// <summary>
        /// Get user details by user name 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <returns>Task of StorefrontUser</returns>
        public async System.Threading.Tasks.Task<StorefrontUser> StorefrontSecurityGetUserByNameAsync(string userName)
        {
             ApiResponse<StorefrontUser> localVarResponse = await StorefrontSecurityGetUserByNameAsyncWithHttpInfo(userName);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get user details by user name 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <returns>Task of ApiResponse (StorefrontUser)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<StorefrontUser>> StorefrontSecurityGetUserByNameAsyncWithHttpInfo(string userName)
        {
            // verify the required parameter 'userName' is set
            if (userName == null)
                throw new ApiException(400, "Missing required parameter 'userName' when calling VirtoCommerceCoreApi->StorefrontSecurityGetUserByName");

            var localVarPath = "/api/storefront/security/user/name/{userName}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (userName != null) localVarPathParams.Add("userName", ApiClient.ParameterToString(userName)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserByName: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityGetUserByName: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<StorefrontUser>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (StorefrontUser)ApiClient.Deserialize(localVarResponse, typeof(StorefrontUser)));
            
        }
        /// <summary>
        /// Sign in with user name and password 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>SignInResult</returns>
        public SignInResult StorefrontSecurityPasswordSignIn(string userName, string password)
        {
             ApiResponse<SignInResult> localVarResponse = StorefrontSecurityPasswordSignInWithHttpInfo(userName, password);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Sign in with user name and password 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>ApiResponse of SignInResult</returns>
        public ApiResponse<SignInResult> StorefrontSecurityPasswordSignInWithHttpInfo(string userName, string password)
        {
            // verify the required parameter 'userName' is set
            if (userName == null)
                throw new ApiException(400, "Missing required parameter 'userName' when calling VirtoCommerceCoreApi->StorefrontSecurityPasswordSignIn");
            // verify the required parameter 'password' is set
            if (password == null)
                throw new ApiException(400, "Missing required parameter 'password' when calling VirtoCommerceCoreApi->StorefrontSecurityPasswordSignIn");

            var localVarPath = "/api/storefront/security/user/signin";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (userName != null) localVarQueryParams.Add("userName", ApiClient.ParameterToString(userName)); // query parameter
            if (password != null) localVarQueryParams.Add("password", ApiClient.ParameterToString(password)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityPasswordSignIn: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityPasswordSignIn: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<SignInResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SignInResult)ApiClient.Deserialize(localVarResponse, typeof(SignInResult)));
            
        }

        /// <summary>
        /// Sign in with user name and password 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Task of SignInResult</returns>
        public async System.Threading.Tasks.Task<SignInResult> StorefrontSecurityPasswordSignInAsync(string userName, string password)
        {
             ApiResponse<SignInResult> localVarResponse = await StorefrontSecurityPasswordSignInAsyncWithHttpInfo(userName, password);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Sign in with user name and password 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Task of ApiResponse (SignInResult)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<SignInResult>> StorefrontSecurityPasswordSignInAsyncWithHttpInfo(string userName, string password)
        {
            // verify the required parameter 'userName' is set
            if (userName == null)
                throw new ApiException(400, "Missing required parameter 'userName' when calling VirtoCommerceCoreApi->StorefrontSecurityPasswordSignIn");
            // verify the required parameter 'password' is set
            if (password == null)
                throw new ApiException(400, "Missing required parameter 'password' when calling VirtoCommerceCoreApi->StorefrontSecurityPasswordSignIn");

            var localVarPath = "/api/storefront/security/user/signin";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (userName != null) localVarQueryParams.Add("userName", ApiClient.ParameterToString(userName)); // query parameter
            if (password != null) localVarQueryParams.Add("password", ApiClient.ParameterToString(password)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityPasswordSignIn: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityPasswordSignIn: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<SignInResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SignInResult)ApiClient.Deserialize(localVarResponse, typeof(SignInResult)));
            
        }
        /// <summary>
        /// Reset a password for the user 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <returns>SecurityResult</returns>
        public SecurityResult StorefrontSecurityResetPassword(string userId, string token, string newPassword)
        {
             ApiResponse<SecurityResult> localVarResponse = StorefrontSecurityResetPasswordWithHttpInfo(userId, token, newPassword);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Reset a password for the user 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <returns>ApiResponse of SecurityResult</returns>
        public ApiResponse<SecurityResult> StorefrontSecurityResetPasswordWithHttpInfo(string userId, string token, string newPassword)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling VirtoCommerceCoreApi->StorefrontSecurityResetPassword");
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling VirtoCommerceCoreApi->StorefrontSecurityResetPassword");
            // verify the required parameter 'newPassword' is set
            if (newPassword == null)
                throw new ApiException(400, "Missing required parameter 'newPassword' when calling VirtoCommerceCoreApi->StorefrontSecurityResetPassword");

            var localVarPath = "/api/storefront/security/user/password/reset";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (userId != null) localVarQueryParams.Add("userId", ApiClient.ParameterToString(userId)); // query parameter
            if (token != null) localVarQueryParams.Add("token", ApiClient.ParameterToString(token)); // query parameter
            if (newPassword != null) localVarQueryParams.Add("newPassword", ApiClient.ParameterToString(newPassword)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityResetPassword: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityResetPassword: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<SecurityResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SecurityResult)ApiClient.Deserialize(localVarResponse, typeof(SecurityResult)));
            
        }

        /// <summary>
        /// Reset a password for the user 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <returns>Task of SecurityResult</returns>
        public async System.Threading.Tasks.Task<SecurityResult> StorefrontSecurityResetPasswordAsync(string userId, string token, string newPassword)
        {
             ApiResponse<SecurityResult> localVarResponse = await StorefrontSecurityResetPasswordAsyncWithHttpInfo(userId, token, newPassword);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Reset a password for the user 
        /// </summary>
        /// <exception cref="VirtoCommerce.CoreModule.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <returns>Task of ApiResponse (SecurityResult)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<SecurityResult>> StorefrontSecurityResetPasswordAsyncWithHttpInfo(string userId, string token, string newPassword)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling VirtoCommerceCoreApi->StorefrontSecurityResetPassword");
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling VirtoCommerceCoreApi->StorefrontSecurityResetPassword");
            // verify the required parameter 'newPassword' is set
            if (newPassword == null)
                throw new ApiException(400, "Missing required parameter 'newPassword' when calling VirtoCommerceCoreApi->StorefrontSecurityResetPassword");

            var localVarPath = "/api/storefront/security/user/password/reset";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] {
            };
            string localVarHttpContentType = ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] {
                "application/json", 
                "text/json", 
                "application/xml", 
                "text/xml"
            };
            string localVarHttpHeaderAccept = ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (userId != null) localVarQueryParams.Add("userId", ApiClient.ParameterToString(userId)); // query parameter
            if (token != null) localVarQueryParams.Add("token", ApiClient.ParameterToString(token)); // query parameter
            if (newPassword != null) localVarQueryParams.Add("newPassword", ApiClient.ParameterToString(newPassword)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400 && (localVarStatusCode != 404 || Configuration.ThrowExceptionWhenStatusCodeIs404))
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityResetPassword: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling StorefrontSecurityResetPassword: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<SecurityResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SecurityResult)ApiClient.Deserialize(localVarResponse, typeof(SecurityResult)));
            
        }
    }
}
