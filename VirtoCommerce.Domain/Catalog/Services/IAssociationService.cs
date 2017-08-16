using VirtoCommerce.Domain.Catalog.Model;

namespace VirtoCommerce.Domain.Catalog.Services
{
    public interface IAssociationService
    {
        void LoadAssociations(IHasAssociations[] owners);

        void LoadReferencedAssociations(IHasReferencedAssociations[] owners);

        void SaveChanges(IHasAssociations[] owners);
    }
}
