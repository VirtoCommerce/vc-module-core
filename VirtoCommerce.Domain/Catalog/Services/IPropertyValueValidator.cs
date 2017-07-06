using VirtoCommerce.Domain.Catalog.Model;

namespace VirtoCommerce.Domain.Catalog.Services
{
    public interface IPropertyValueValidator
    {
        string[] Validate(PropertyValidationRule validationRule, PropertyValue value);
    }
}
