namespace VirtoCommerce.Domain.Search
{
    public class GeoDistanceFilter : IFilter
    {
        public string FieldName { get; set; }

        /// <summary>
        /// The point from which the distance is measured
        /// </summary>
        public GeoPoint Location { get; set; }

        /// <summary>
        /// Max distance in kilometers
        /// </summary>
        public double Distance { get; set; }

        public override string ToString()
        {
            return $"DISTANCE({FieldName}, {Location}, {Distance})";
        }
    }
}
