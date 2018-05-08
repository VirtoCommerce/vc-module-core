using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Omu.ValueInjecter;
using coreModel = VirtoCommerce.Domain.Commerce.Model;
using dataModel = VirtoCommerce.CoreModule.Data.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Data.Common.ConventionInjections;

namespace VirtoCommerce.CoreModule.Data.Converters
{
    public static class PackageTypeConverter
    {

        public static coreModel.PackageType ToCoreModel(this dataModel.PackageType packageType)
        {
            var retVal = new coreModel.PackageType();
            retVal.InjectFrom(packageType);
            return retVal;
        }

        public static dataModel.PackageType ToDataModel(this coreModel.PackageType packageType)
        {
            var retVal = new dataModel.PackageType();
            retVal.InjectFrom(packageType);
            return retVal;
        }


        /// <summary>
        /// Patch changes
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void Patch(this dataModel.PackageType source, dataModel.PackageType target)
        {
            if (target == null)
                throw new ArgumentNullException("target");

            target.Name = source.Name;
            target.MeasureUnit = source.MeasureUnit;
            target.Length = source.Length;
            target.Width = source.Width;
            target.Height = source.Height;
        }


    }
}