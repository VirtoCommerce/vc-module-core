using System;
using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Search
{
    public class GeoSortInfo : SortInfo
    {
        public GeoPoint GeoPoint { get; set; }

        /// <summary>
        /// [-|+]222.222,[+|-]222.222:[asc|desc]
        /// </summary>
        /// <param name="sortExpr"></param>
        /// <returns></returns>
        public static IEnumerable<SortInfo> TryParse(string sortExpr)
        {
            var result = new List<SortInfo>();
            if (!string.IsNullOrEmpty(sortExpr))
            {
                var sortInfoStrings = sortExpr.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var sortInfoString in sortInfoStrings)
                {
                    var geoPoint = GeoPoint.TryParse(sortInfoString);
                    if (geoPoint != null)
                    {
                        var geoSortInfo = new GeoSortInfo
                        {
                            GeoPoint = geoPoint,
                            SortDirection = sortInfoString.ToLowerInvariant().Contains(":desc") ? SortDirection.Descending : SortDirection.Ascending
                        };
                        result.Add(geoSortInfo);
                    }
                    else
                    {
                        result.AddRange(Parse(sortInfoString));
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            return $"{GeoPoint?.ToString()}:{ base.ToString() }";
        }

        public override bool Equals(object obj)
        {
            var result = base.Equals(obj);
            if (obj is GeoSortInfo other)
            {
                result = GeoPoint == other.GeoPoint;
            }
            return result;
        }

        public override int GetHashCode()
        {
            return GeoPoint != null ? GeoPoint.GetHashCode() : base.GetHashCode();
        }
    }
}
