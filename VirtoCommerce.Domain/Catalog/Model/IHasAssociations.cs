using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    public interface IHasAssociations : IEntity
    {
        ICollection<ProductAssociation> Associations { get; set; }
    }
}
