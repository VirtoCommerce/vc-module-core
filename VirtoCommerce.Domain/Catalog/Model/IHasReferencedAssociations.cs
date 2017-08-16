using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    public interface IHasReferencedAssociations : IEntity
    {
        ICollection<ProductAssociation> ReferencedAssociations { get; set; }
    }
}
