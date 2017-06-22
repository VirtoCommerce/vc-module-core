using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace VirtoCommerce.Domain.Search
{
    public class GeoPoint
    {
        private static readonly Regex _parseRegex = new Regex(@"(-?\d+(?:\.\d+)?),\s*(-?\d+(?:\.\d+)?)", RegexOptions.Compiled);

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}, {1}", Latitude, Longitude);
        }

        public static GeoPoint Parse(string value)
        {
            var match = _parseRegex.Match(value);

            if (!match.Success || match.Groups.Count != 3)
            {
                throw new ArgumentException("", nameof(value));
            }

            return new GeoPoint
            {
                Latitude = double.Parse(match.Groups[1].Value, NumberStyles.Float, CultureInfo.InvariantCulture),
                Longitude = double.Parse(match.Groups[2].Value, NumberStyles.Float, CultureInfo.InvariantCulture),
            };
        }
    }
}
