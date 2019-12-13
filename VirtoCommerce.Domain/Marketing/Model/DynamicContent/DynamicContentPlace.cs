using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Marketing.Model
{
    public class DynamicContentPlace : AuditableEntity, IsHasFolder
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Outline => Folder?.Outline;
        public string Path => Folder?.Path;

        #region IHasFolder Members
        public string FolderId { get; set; }
        public DynamicContentFolder Folder { get; set; }
        #endregion
    }
}
