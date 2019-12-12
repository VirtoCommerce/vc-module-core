using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.DynamicProperties;

namespace VirtoCommerce.Domain.Marketing.Model
{
    public class DynamicContentItem : AuditableEntity, IsHasFolder, IHasDynamicProperties
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public string ImageUrl { get; set; }
        public int Priority { get; set; }
        public string Outline => Folder?.Outline;
        public string Path => Folder?.Path;

        #region IHasFolder Members
        public string FolderId { get; set; }
        public DynamicContentFolder Folder { get; set; }
        #endregion

        #region IHasDynamicProperties Members
        public string ObjectType { get; set; }
        public ICollection<DynamicObjectProperty> DynamicProperties { get; set; }
        #endregion
    }
}
