using System;
using System.ComponentModel.DataAnnotations;
using VirtoCommerce.CoreModule.Core.NumberGenerators;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Data.Model
{
    public class NumberGeneratorDescriptorEntity : AuditableEntity
    {
        [StringLength(64)]
        public string TargetType { get; set; }

        [Required]
        [StringLength(64)]
        public string Template { get; set; }

        [StringLength(128)]
        public string TenantId { get; set; }
        public bool IsActive { get; set; }
        public int Start { get; set; }
        public int Increment { get; set; }
        public DateTime LastResetDate { get; set; }

        public virtual NumberGeneratorDescriptor ToModel(NumberGeneratorDescriptor item)
        {
            item.Id = Id;
            item.CreatedBy = CreatedBy;
            item.CreatedDate = CreatedDate;
            item.ModifiedBy = ModifiedBy;
            item.ModifiedDate = ModifiedDate;

            item.TargetType = TargetType;
            item.Template = Template;
            item.TenantId = TenantId;
            item.IsActive = IsActive;
            item.Start = Start;
            item.Increment = Increment;
            item.LastResetDate = LastResetDate;
            return item;
        }

        public virtual NumberGeneratorDescriptorEntity FromModel(NumberGeneratorDescriptor item)
        {
            Id = item.Id;
            CreatedBy = item.CreatedBy;
            CreatedDate = item.CreatedDate;
            ModifiedBy = item.ModifiedBy;
            ModifiedDate = item.ModifiedDate;

            TargetType = item.TargetType;
            Template = item.Template;
            TenantId = item.TenantId;
            IsActive = item.IsActive;
            Start = item.Start;
            Increment = item.Increment;
            LastResetDate = item.LastResetDate;

            return this;
        }

        public virtual void Patch(NumberGeneratorDescriptorEntity item)
        {
            item.Template = Template;
            item.IsActive = IsActive;
            item.Start = Start;
            item.Increment = Increment;
            item.LastResetDate = LastResetDate;
        }
    }
}
