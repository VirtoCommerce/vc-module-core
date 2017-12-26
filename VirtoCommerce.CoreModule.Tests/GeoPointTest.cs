using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Catalog.Model.Search;
using VirtoCommerce.Domain.Search;
using VirtoCommerce.Platform.Core.Common;
using Xunit;

namespace VirtoCommerce.CoreModule.Tests
{
    public class GeoPointTest
    {

        [Fact]
        public virtual void CanTryParseSortString()
        {
            var geoSortInfo = new GeoSortInfo
            {
                SortColumn = "location2",
                GeoPoint = new GeoPoint
                {
                    Latitude = 54.7322,
                    Longitude = 20.5258
                },
                SortDirection = SortDirection.Ascending
            };

            var searchCriteria = new ProductSearchCriteria
            {
                Sort = "location2(54.7322,20.5258):asc;name:desc"
            };

            var result = searchCriteria.SortInfos;

            Assert.Equal(2, result.Length);
            Assert.Equal(geoSortInfo, result[0]);
        }

        [CLSCompliant(false)]
        [Theory]
        [InlineData(22.33 , -22.33, "22.33, -22.33")]
        [InlineData(22.33, 22.33, "22.33,    22.33")]
        [InlineData(2.33, 2.33, "2.33,2.33")]
        public virtual void CanTryParseGeoPoint( double lat, double lot, string location)
        {
            var result = GeoPoint.Parse(location);

            var geoPoint = new GeoPoint { Latitude = lat, Longitude = lot };

            Assert.Equal(geoPoint, result);
        }
    }
}
