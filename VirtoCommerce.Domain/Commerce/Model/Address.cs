using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Commerce.Model
{
    public class Address : ValueObject
	{
        //Temporary workaround to be able make references to the address
        public string Key { get; set; }

		public AddressType AddressType { get; set; }
		public string Name { get; set; }
		public string Organization { get; set; }
		public string CountryCode { get; set; }
		public string CountryName { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Zip { get; set; }
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string RegionId { get; set; }
		public string RegionName { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            //Return all properties except Key
            yield return AddressType;
            yield return Name;
            yield return Organization;
            yield return CountryCode;
            yield return CountryName;
            yield return City;
            yield return PostalCode;
            yield return Zip;
            yield return Line1;
            yield return Line2;
            yield return RegionId;
            yield return RegionName;
            yield return FirstName;
            yield return MiddleName;
            yield return LastName;
            yield return Phone;
            yield return Email;
        }
    }

}
