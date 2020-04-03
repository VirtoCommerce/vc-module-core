using System;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Core.NumberGenerators
{
    public class NumberGeneratorDescriptor : AuditableEntity
    {
        public string TargetType { get; set; }
        public string Template { get; set; }
        public string TenantId { get; set; }
        public bool IsActive { get; set; }
        public int Start { get; set; }
        public int Increment { get; set; }
        public DateTime? LastResetDate { get; set; }
    }
}
