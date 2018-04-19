using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtoCommerce.Platform.Core.Common;
using coreModel = VirtoCommerce.Domain.Commerce.Model;
using dataModel = VirtoCommerce.CoreModule.Data.Model;

namespace VirtoCommerce.CoreModule.Data.Model
{
    public class SeoUrlKeyword : AuditableEntity
	{
		[StringLength(5)]
		public string Language { get; set; }

		[StringLength(255)]
		[Required]		
        [Index("KeywordStoreId", Order = 1)]
        public string Keyword { get; set; }

		[StringLength(255)]
		[Required]
        [Index("ObjectIdAndObjectType", 1)]
        public string ObjectId { get; set; }

		[Required]
		public bool IsActive { get; set; }

		[StringLength(64)]
		[Required]
        [Index("ObjectIdAndObjectType", 2)]
        public string ObjectType { get; set; }

        [StringLength(128)]
        [Index("KeywordStoreId", Order = 2)]
        public string StoreId { get; set; }

        [StringLength(255)]
		public string Title { get; set; }

		[StringLength(1024)]
		public string MetaDescription { get; set; }

		[StringLength(255)]
		public string MetaKeywords { get; set; }

		[StringLength(255)]
		public string ImageAltDescription { get; set; }

        public virtual coreModel.SeoInfo ToModel(coreModel.SeoInfo seoInfo)
        {
            seoInfo.Id = Id;
            seoInfo.CreatedBy = CreatedBy;
            seoInfo.CreatedDate = CreatedDate;
            seoInfo.ModifiedBy = ModifiedBy;
            seoInfo.ModifiedDate = ModifiedDate;

            seoInfo.LanguageCode = Language;
            seoInfo.SemanticUrl = Keyword;
            seoInfo.PageTitle = Title;
            seoInfo.ImageAltDescription = ImageAltDescription;
            seoInfo.IsActive = IsActive;
            seoInfo.MetaDescription = MetaDescription;
            seoInfo.MetaKeywords = MetaKeywords;
            seoInfo.ObjectId = ObjectId;
            seoInfo.ObjectType = ObjectType;
            seoInfo.StoreId = StoreId;

            return seoInfo;
        }

        public virtual dataModel.SeoUrlKeyword FromModel(coreModel.SeoInfo seoInfo, PrimaryKeyResolvingMap pkMap)
        {
            pkMap.AddPair(this, seoInfo);

            Id = seoInfo.Id;
            CreatedBy = seoInfo.CreatedBy;
            CreatedDate = seoInfo.CreatedDate;
            ModifiedBy = seoInfo.ModifiedBy;
            ModifiedDate = seoInfo.ModifiedDate;

            Language = seoInfo.LanguageCode;
            Keyword = seoInfo.SemanticUrl;
            Title = seoInfo.PageTitle;
            ImageAltDescription = seoInfo.ImageAltDescription;
            IsActive = seoInfo.IsActive;
            MetaDescription = seoInfo.MetaDescription;
            MetaKeywords = seoInfo.MetaKeywords;
            ObjectId = seoInfo.ObjectId;
            ObjectType = seoInfo.ObjectType;
            StoreId = seoInfo.StoreId;

            return this;
        }

        public virtual void Patch(dataModel.SeoUrlKeyword target)
        {
            target.Language = Language;
            target.Keyword = Keyword;
            target.Title = Title;
            target.ImageAltDescription = ImageAltDescription;
            target.IsActive = IsActive;
            target.MetaDescription = MetaDescription;
            target.MetaKeywords = MetaKeywords;
            target.ObjectId = ObjectId;
            target.ObjectType = ObjectType;
            target.StoreId = StoreId;
        }
    }
}
