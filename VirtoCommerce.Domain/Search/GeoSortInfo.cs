using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Search
{
    public class GeoSortInfo : SortInfo
    {
        private static readonly Regex _hasLocation = new Regex(@"\((?<location>[-+]?([1-8]?\d(.\d+)?|90(.0+)?),\s*[-+]?(180(.0+)?|((1[0-7]\d)|([1-9]?\d))(.\d+)?))\)", RegexOptions.Compiled);

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
                        var part = sortInfoString.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                        if (part.Any())
                        {
                            var geoSortInfo = new GeoSortInfo
                            {
                                GeoPoint = geoPoint,
                                SortColumn = GeoPropertyName(part[0])
                            };

                            if (part.Length > 1)
                            {
                                geoSortInfo.SortDirection = part[1].StartsWith("desc", StringComparison.InvariantCultureIgnoreCase) ? SortDirection.Descending : SortDirection.Ascending;
                            }

                            result.Add(geoSortInfo);
                        }
                    }
                    else
                    {
                        result.AddRange(Parse(sortInfoString));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Get location property name 
        /// </summary>
        /// <param name="location">location(22.22,-22.22)</param>
        /// <returns>location</returns>
        private static string GeoPropertyName(string location)
        {
            string propertyName = string.Empty;

            MatchCollection matches = _hasLocation.Matches(location);

            if (matches.Count == 1)
            {
                foreach (Match match in matches)
                {
                    propertyName = location.Replace(match.Value, "");
                }
            }

            return propertyName;
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
