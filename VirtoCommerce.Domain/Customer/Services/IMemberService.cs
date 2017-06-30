using VirtoCommerce.Domain.Customer.Model;

namespace VirtoCommerce.Domain.Customer.Services
{
    /// <summary>
    /// Abstraction for member CRUD operations
    /// </summary>
    public interface IMemberService
    {
        Member[] GetByIds(string[] memberIds, string responseGroup = null, string[] memberTypes = null);
        void SaveChanges(Member[] members);
        void Delete(string[] ids, string[] memberTypes = null);
    }
}
