using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.Domain.Catalog.Model
{
    /// <summary>
    /// Geo point
    /// </summary>
    public class GeoDistanceCriterion
    {
        private static readonly string pattert = @"[-+]?([1-8]?\d(.\d+)?|90(.0+)?),\s*[-+]?(180(.0+)?|((1[0-7]\d)|([1-9]?\d))(.\d+)?)";
        private static readonly Regex _hasLocation = new Regex(@"\((?<location>[-+]?([1-8]?\d(.\d+)?|90(.0+)?),\s*[-+]?(180(.0+)?|((1[0-7]\d)|([1-9]?\d))(.\d+)?))\)", RegexOptions.Compiled);

        /// <summary>
        /// Property location name
        /// </summary>
        public string GeoPointPropertyName{ get; set; }

        /// <summary>
        /// Location
        /// </summary>
        public GeoPoint GeoPoint { get; set; }

        /// <summary>
        ///  Gets or sets distanse for search by location
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Get location for geo point
        /// </summary>
        /// <param name="location">Location2(44.33,-33.88)</param>
        /// <returns>44.33,-33.88</returns>
        public static GeoPoint GeoLocation(string location)
        {
            string _location = string.Empty;

            MatchCollection matches = _hasLocation.Matches(location);

            if (matches.Count == 1)
            {
                foreach (Match match in matches)
                {
                    GroupCollection groups = match.Groups;
                    _location = groups["location"].Value;
                }
            }

            return GeoPoint.Parse(_location);
        }

        /// <summary>
        /// Get property name for geo point
        /// </summary>
        /// <param name="location">Location2(44.33,-33.88)</param>
        /// <returns>Location2</returns>
        public static string GeoPropertyName(string location)
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

        //Sorting string have geo point (44.00,-58.88)
        /// <summary>
        /// Sorting string have geo point
        /// </summary>
        /// <param name="location">Location2(44.33,-33.88):desc</param>
        /// <returns></returns>
        public static bool HasGeoPoitnAtSortingString(string location)
        {
            return _hasLocation.IsMatch(location);
        }

        /// <summary>
        /// Add custom validation rules
        /// </summary>
        /// <returns></returns>
        public static List<PropertyValidationRule> GeoPointPropertyValidationRules()
        {
            List<PropertyValidationRule> validationRules = new List<PropertyValidationRule>
            {
                new PropertyValidationRule { RegExp = pattert }
            };

            return validationRules;

        }
    }
}
