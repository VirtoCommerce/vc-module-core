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
        [InlineData(90 , -127.554334, "+90.0, -127.554334")]
        [InlineData(45, 180, "45, 180")]
        [InlineData(90, -180, "90, -180")]
        [InlineData(-90.000, -180.0000, "-90.000, -180.0000")]
        [InlineData(90, 180, "+90, +180")]
        [InlineData(47.1231231, 179.9999999, "47.1231231, 179.9999999")]
        public virtual void CanTryParseGeoPoint( double lat, double lot, string point)
        {
            var result = GeoPoint.TryParse(point);

            var geoPoint = new GeoPoint { Latitude = lat, Longitude = lot };

            Assert.Equal(geoPoint, result);
        }

        [CLSCompliant(false)]
        [Theory]
        [InlineData("+90.1, -100.111")]
        [InlineData("-91, 123.456")]
        [InlineData("045, 180")]
        public virtual void CantTryParseGeoPoint(string point)
        {
            var result = GeoPoint.TryParse(point);
            Assert.Null(result);
        }
    }
}
