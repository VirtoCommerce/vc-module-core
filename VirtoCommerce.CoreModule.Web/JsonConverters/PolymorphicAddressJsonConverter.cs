using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Web.JsonConverters
{
    public class PolymorphicAddressJsonConverter : JsonConverter
    {
        private static Type[] _knowTypes = new[] { typeof(Address) };

        public PolymorphicAddressJsonConverter()
        {
        }

        public override bool CanWrite { get { return false; } }
        public override bool CanRead { get { return true; } }

        public override bool CanConvert(Type objectType)
        {
            return _knowTypes.Any(x => x.IsAssignableFrom(objectType));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object retVal = null;
            var obj = JObject.Load(reader);

            if (typeof(Address).IsAssignableFrom(objectType))
            {
                retVal = AbstractTypeFactory<Address>.TryCreateInstance();
            }
            serializer.Populate(obj.CreateReader(), retVal);
            return retVal;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
