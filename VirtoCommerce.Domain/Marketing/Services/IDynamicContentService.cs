using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Marketing.Model;

namespace VirtoCommerce.Domain.Marketing.Services
{
	public interface IDynamicContentService
	{
		DynamicContentFolder[] GetFoldersByIds(string[] ids);
        void SaveFolders(DynamicContentFolder[] folders);	
		void DeleteFolders(string[] ids);

		DynamicContentItem[] GetContentItemsByIds(string[] ids);
        void SaveContentItems(DynamicContentItem[] items);
		void DeleteContentItems(string[] ids);

		DynamicContentPlace[] GetPlacesByIds(string[] ids);
        void SavePlaces(DynamicContentPlace[] places);
        void DeletePlaces(string[] ids);

		DynamicContentPublication[] GetPublicationsByIds(string[] ids);
		void SavePublications(DynamicContentPublication[] publications);
		void DeletePublications(string[] ids);
	}
}
