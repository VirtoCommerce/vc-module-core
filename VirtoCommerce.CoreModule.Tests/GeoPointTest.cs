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

        [Fact]
        public virtual void CanTryParsegeoPoint()
        {
            var result1 = GeoPoint.Parse("54.7322, 20.5258 ");
            var result2 = GeoPoint.Parse("34.05,-118.24");

            var geoPoint1 = new GeoPoint { Latitude = 54.7322, Longitude = 20.5258 };
            var geoPoint2 = new GeoPoint { Latitude = 34.05, Longitude = -118.24 };

            Assert.Equal(geoPoint1, result1);
            Assert.Equal(geoPoint2, result2);

        }
    }
}
