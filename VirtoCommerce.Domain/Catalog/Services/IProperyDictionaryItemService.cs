using VirtoCommerce.Domain.Catalog.Model;

namespace VirtoCommerce.Domain.Catalog.Services
{
    /// <summary>
    /// The abstraction represent the CRUD operations for property dictionary items
    /// </summary>
    public interface IProperyDictionaryItemService
    {
        PropertyDictionaryItem[] GetByIds(string[] ids);
        void SaveChanges(PropertyDictionaryItem[] dictItems);
        void Delete(string[] ids);
    }
}
