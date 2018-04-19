using System;
using System.ComponentModel.DataAnnotations;
using VirtoCommerce.Platform.Core.Common;
using coreModel = VirtoCommerce.Domain.Commerce.Model;
using dataModel = VirtoCommerce.CoreModule.Data.Model;

namespace VirtoCommerce.CoreModule.Data.Model
{
	public class FulfillmentCenter : AuditableEntity
	{
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [StringLength(1024)]
        public string Line1 { get; set; }

        [StringLength(1024)]
        public string Line2 { get; set; }

        [StringLength(128)]
        public string City { get; set; }

        [StringLength(64)]
        public string CountryCode { get; set; }

        [StringLength(128)]
        public string StateProvince { get; set; }

        [StringLength(128)]
        public string CountryName { get; set; }

        [StringLength(32)]
        public string PostalCode { get; set; }

        [StringLength(128)]
        public string RegionId { get; set; }

        [StringLength(128)]
        public string RegionName { get; set; }

        [StringLength(64)]
        public string DaytimePhoneNumber { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(128)]
        public string Organization { get; set; }

        [StringLength(64)]
        public string GeoLocation { get; set; }

        public virtual coreModel.FulfillmentCenter ToModel(coreModel.FulfillmentCenter center)
        {
            center.City = City;
            center.CountryCode = CountryCode;
            center.CountryName = CountryName;
            center.DaytimePhoneNumber = DaytimePhoneNumber;
            center.Description = Description;
            center.Id = Id;
            center.Line1 = Line1;
            center.Line2 = Line2;
            center.Name = Name;
            center.PostalCode = PostalCode;
            center.StateProvince = StateProvince;
            
            return center;
        }

        public virtual dataModel.FulfillmentCenter FromModel(coreModel.FulfillmentCenter center, PrimaryKeyResolvingMap pkMap)
        {
            pkMap.AddPair(this, center);

            City = center.City;
            CountryCode = center.CountryCode;
            CountryName = center.CountryName;
            DaytimePhoneNumber = center.DaytimePhoneNumber;
            Description = center.Description;
            Id = center.Id;
            Line1 = center.Line1;
            Line2 = center.Line2;
            Name = center.Name;
            PostalCode = center.PostalCode;
            StateProvince= center.StateProvince;
            return this;

        }

        public virtual void Patch(dataModel.FulfillmentCenter target)
        {
            target.City = City;
            target.CountryCode = CountryCode;
            target.CountryName = CountryName;
            target.DaytimePhoneNumber = DaytimePhoneNumber;
            target.Description = Description;
            target.Line1 = Line1;
            target.Line2 = Line2;
            target.Name = Name;
            target.PostalCode = PostalCode;
            target.StateProvince = StateProvince;
        }
    }
}
