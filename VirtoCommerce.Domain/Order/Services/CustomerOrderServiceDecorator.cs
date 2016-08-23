using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Common;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Order.Services
{  
    public sealed class CustomerOrderServiceDecorator : ICustomerOrderService, ICustomerOrderSearchService
    {        
        #region IOrderOperationService Members
        public CustomerOrder[] GetByIds(string[] operationIds, string responseGroup = null)
        {
            var retVal = new ConcurrentBag<CustomerOrder>();
            var orderServiceGroups = GetServiceTypeInfoGroups<ICustomerOrderService>();
            Parallel.ForEach(orderServiceGroups, (serviceGroup) =>
            {
                foreach (var order in serviceGroup.Key.GetByIds(operationIds, responseGroup))
                {
                    retVal.Add(order);
                }
            });
            return retVal.ToArray();
        }

        public void SaveChanges(CustomerOrder[] orders)
        {
            var orderServiceGroups = GetServiceTypeInfoGroups<ICustomerOrderService>();
            Parallel.ForEach(orderServiceGroups, (serviceGroup) =>
            {
                var allInheritedTypeNames = serviceGroup.SelectMany(m => m.AllInheritedTypeNames).Distinct().ToArray();
                var matchOrders = orders.Where(x => allInheritedTypeNames.Contains(x.ObjectType, StringComparer.OrdinalIgnoreCase)).ToArray();
                if (!matchOrders.IsNullOrEmpty())
                {
                    serviceGroup.Key.SaveChanges(matchOrders);
                }
            });
        }

        public void Delete(string[] ids)
        {
            var orderServiceGroups = GetServiceTypeInfoGroups<ICustomerOrderService>();
            Parallel.ForEach(orderServiceGroups, (serviceGroup) =>
            {
                serviceGroup.Key.Delete(ids);
            });
        }
        #endregion

        #region IOrderOperationSearchService Members
        /// <summary>
        /// Search in multiple data sources. 
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public GenericSearchResult<CustomerOrder> SearchCustomerOrders(CustomerOrderSearchCriteria criteria)
        {
            var retVal = new GenericSearchResult<CustomerOrder>();
            var skip = criteria.Skip;
            var take = criteria.Take;
            var objectTypes = criteria.ObjectTypes;
            /// !!!Ahtung!!!: Because operations can be searched in multiple data sources we have to always use sorting by operationType field (asc or desc) 
            /// instead pagination will not works properly
            var sortByOperationType = criteria.SortInfos.FirstOrDefault(x => string.Equals(x.SortColumn, "objectType", StringComparison.OrdinalIgnoreCase)) ?? new SortInfo { SortColumn = "objectType" };
            var sortInfos = criteria.SortInfos.Where(x => x != sortByOperationType);
            criteria.Sort = SortInfo.ToString(new[] { sortByOperationType }.Concat(sortInfos));

            var operationSearchServiceGroups = GetServiceTypeInfoGroups<ICustomerOrderSearchService>();
            foreach (var serviceGroup in operationSearchServiceGroups)
            {
                var allInheritedTypeNames = serviceGroup.SelectMany(m => m.AllInheritedTypeNames).Distinct().ToArray();
                criteria.ObjectTypes = objectTypes.IsNullOrEmpty() ? allInheritedTypeNames : allInheritedTypeNames.Intersect(objectTypes, StringComparer.OrdinalIgnoreCase).ToArray();
                if (!criteria.ObjectTypes.IsNullOrEmpty() && criteria.Take >= 0)
                {
                    var result = serviceGroup.Key.SearchCustomerOrders(criteria);
                    retVal.Results.AddRange(result.Results);
                    retVal.TotalCount += result.TotalCount;
                    criteria.Skip = Math.Max(0, skip - retVal.TotalCount);
                    criteria.Take = Math.Max(0, take - result.Results.Count());
                }
            }
            //restore back criteria property values
            criteria.Skip = skip;
            criteria.Take = take;
            criteria.ObjectTypes = objectTypes;
            return retVal;
        }
        #endregion

        private IEnumerable<IGrouping<T, TypeInfo<OrderOperation>>> GetServiceTypeInfoGroups<T>()
        {
            return AbstractTypeFactory<OrderOperation>.AllTypeInfos.GroupBy(x => x.GetService<T>());
        }
    }  
}
