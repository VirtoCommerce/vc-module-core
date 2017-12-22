using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Search;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model.Search
{
    public class ProductSearchCriteria : CatalogSearchCriteriaBase
    {
        public override string ObjectType { get; set; } = KnownDocumentTypes.Product;

        public string Currency { get; set; }

        public string[] Pricelists { get; set; }

        public NumericRange PriceRange { get; set; }

        /// <summary>
        /// Gets or sets the class types.
        /// </summary>
        /// <value>The class types.</value>
        public virtual IList<string> ClassTypes { get; set; } = new List<string>();

        /// <summary>
        /// Specifies if we search for hidden products.
        /// </summary>
        public virtual bool WithHidden { get; set; }

        /// <summary>
        /// Gets or sets the start date. The date must be in UTC format as that is format indexes are stored in.
        /// </summary>
        /// <value>The start date.</value>
        public virtual DateTime StartDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the start date from filter. Used for filtering new products. The date must be in UTC format as that is format indexes are stored in.
        /// </summary>
        /// <value>The start date from.</value>
        public virtual DateTime? StartDateFrom { get; set; }

        /// <summary>
        /// Gets or sets the end date. The date must be in UTC format as that is format indexes are stored in.
        /// </summary>
        /// <value>The end date.</value>
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets a "white" list of aggregation keys that identify preconfigured aggregations, which SHOULD be calculated and returned with the search result.
        /// </summary>
        public IList<string> IncludeAggregations { get; set; }

        /// <summary>
        /// Gets or sets a "black" list of aggregation keys that identify preconfigured aggregations, which SHOULD NOT be calculated and returned with the search result.
        /// </summary>
        public IList<string> ExcludeAggregations { get; set; }
        /// <summary>
        /// Geo distance criterion
        /// </summary>
        public GeoDistanceCriterion GeoDistanceCriterion { get; set; }

        public override SortInfo[] SortInfos => SortParse(Sort).ToArray();

        /// <summary>
        /// Parse string sort expression with true parse location 
        /// </summary>
        /// <param name="sortExpr"></param>
        /// <returns></returns>
        private IEnumerable<SortInfo> SortParse(string sortExpr)
        {
            var retVal = new List<SortInfo>();
            if (string.IsNullOrEmpty(sortExpr))
                return retVal;

            var sortInfoStrings = sortExpr.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var sortInfoString in sortInfoStrings)
            {
                //if sorting string contains location
                if (GeoDistanceCriterion.HasGeoPoitnAtSortingString(sortInfoString))
                {
                    var part = sortInfoString.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);

                    if (part.Any())
                    {
                        var sortInfo = new SortInfo
                        {
                            SortColumn = part[0],
                            SortDirection = SortDirection.Ascending
                        };

                        if (part.Length > 1)
                        {
                            sortInfo.SortDirection =
                                part[1].StartsWith("desc", StringComparison.InvariantCultureIgnoreCase)
                                    ? SortDirection.Descending
                                    : SortDirection.Ascending;
                        }

                        retVal.Add(sortInfo);
                    }
                }
                else
                {
                    retVal.AddRange(SortInfo.Parse(sortInfoString));
                }
            }

            return retVal;
        }
    }
}
