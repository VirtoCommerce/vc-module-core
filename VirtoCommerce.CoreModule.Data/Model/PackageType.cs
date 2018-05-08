using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Data.Model
{
    public class PackageType : Entity
    {
        [Required]
        [StringLength(254)]
        public string Name { get; set; }

        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        [StringLength(16)]
        public string MeasureUnit { get; set; }

    }
}
