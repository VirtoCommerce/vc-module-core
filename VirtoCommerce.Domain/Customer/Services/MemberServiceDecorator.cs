using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Customer.Services
{
    public sealed class MemberServiceDecorator : IMemberSearchService, IMemberService
    {
        #region IMemberService Members
        public Member[] GetByIds(string[] memberIds, string responseGroup = null, string[] memberTypes = null)
        {
            var retVal = new ConcurrentBag<Member>();
            var memberServiceGroups = GetServiceTypeInfoGroups<IMemberService>();
            Parallel.ForEach(memberServiceGroups, (serviceGroup) =>
            {
                foreach (var order in serviceGroup.Key.GetByIds(memberIds, responseGroup, memberTypes))
                {
                    retVal.Add(order);
                }
            });
            return retVal.ToArray();
        }

        public void SaveChanges(Member[] members)
        {
            var memberServiceGroups = GetServiceTypeInfoGroups<IMemberService>();
            Parallel.ForEach(memberServiceGroups, (serviceGroup) =>
            {
                var serviceKnowMemberTypeNames = serviceGroup.SelectMany(m => m.AllSubclasses.Select(x => x.Name)).Distinct().ToArray();
                var matchMembers = members.Where(x => serviceKnowMemberTypeNames.Contains(x.MemberType, StringComparer.OrdinalIgnoreCase)).ToArray();
                if (!matchMembers.IsNullOrEmpty())
                {
                    serviceGroup.Key.SaveChanges(matchMembers);
                }
            });
        }

        public void Delete(string[] ids, string[] memberTypes = null)
        {
            var memberServiceGroups = GetServiceTypeInfoGroups<IMemberService>();
            Parallel.ForEach(memberServiceGroups, (serviceGroup) =>
            {
                var serviceKnowMemberTypeNames = serviceGroup.SelectMany(m => m.AllSubclasses.Select(x => x.Name)).Distinct().ToArray();
                serviceGroup.Key.Delete(ids, serviceKnowMemberTypeNames.ToArray());
            });
        }
        #endregion

        #region IMemberSearchService Members
        /// <summary>
        /// Search in multiple data sources. 
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public GenericSearchResult<Member> SearchMembers(MembersSearchCriteria criteria)
        {
            var retVal = new GenericSearchResult<Member>();
            var skip = criteria.Skip;
            var take = criteria.Take;
            var memberTypes = criteria.MemberTypes;
            /// !!!Ahtung!!!: Because operations can be searched in multiple data sources we have to always use sorting by operationType field (asc or desc) 
            /// instead pagination will not works properly
            var sortByOperationType = criteria.SortInfos.FirstOrDefault(x => string.Equals(x.SortColumn, "memberType", StringComparison.OrdinalIgnoreCase)) ?? new SortInfo { SortColumn = "memberType" };
            var sortInfos = criteria.SortInfos.Where(x => x != sortByOperationType);
            criteria.Sort = SortInfo.ToString(new[] { sortByOperationType }.Concat(sortInfos));

            var operationSearchServiceGroups = GetServiceTypeInfoGroups<IMemberSearchService>();
            foreach (var serviceGroup in operationSearchServiceGroups)
            {
                var allInheritedTypeNames = serviceGroup.SelectMany(m => m.AllSubclasses.Select(x => x.Name)).Distinct().ToArray();
                criteria.MemberTypes = memberTypes.IsNullOrEmpty() ? allInheritedTypeNames : allInheritedTypeNames.Intersect(memberTypes, StringComparer.OrdinalIgnoreCase).ToArray();
                if (!criteria.MemberTypes.IsNullOrEmpty() && criteria.Take >= 0)
                {
                    var result = serviceGroup.Key.SearchMembers(criteria);
                    retVal.Results.AddRange(result.Results);
                    retVal.TotalCount += result.TotalCount;
                    criteria.Skip = Math.Max(0, skip - retVal.TotalCount);
                    criteria.Take = Math.Max(0, take - result.Results.Count());
                }
            }
            //restore back criteria property values
            criteria.Skip = skip;
            criteria.Take = take;
            criteria.MemberTypes = memberTypes;
            return retVal;
        }
        #endregion

        private IEnumerable<IGrouping<T, TypeInfo<Member>>> GetServiceTypeInfoGroups<T>()
        {
            return AbstractTypeFactory<Member>.AllTypeInfos.GroupBy(x => x.GetService<T>()).Where(x=>x.Key != null);
        }
    }  
}
