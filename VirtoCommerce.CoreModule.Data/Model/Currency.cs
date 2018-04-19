using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtoCommerce.Platform.Core.Common;
using coreModel = VirtoCommerce.Domain.Commerce.Model;
using dataModel = VirtoCommerce.CoreModule.Data.Model;

namespace VirtoCommerce.CoreModule.Data.Model
{
    public class Currency : AuditableEntity
    {
        [Required]
        [StringLength(16)]
        [Index("IX_Code")]
        public string Code { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public bool IsPrimary { get; set; }

        [Column(TypeName = "Money")]
        public decimal ExchangeRate { get; set; }

        [StringLength(16)]
        public string Symbol { get; set; }

        [StringLength(64)]
        public string CustomFormatting { get; set; }

        public virtual coreModel.Currency ToModel(coreModel.Currency currency)
        {
            currency.Code = Code;
            currency.Name = Name;
            currency.IsPrimary = IsPrimary;
            currency.ExchangeRate = ExchangeRate;
            currency.Symbol = Symbol;
            currency.CustomFormatting = CustomFormatting;         
            return currency;
        }

        public virtual dataModel.Currency FromModel(coreModel.Currency currency)
        {
            Code = currency.Code;
            Name = currency.Name;
            IsPrimary = currency.IsPrimary;
            ExchangeRate = currency.ExchangeRate;
            Symbol = currency.Symbol;
            CustomFormatting = currency.CustomFormatting;
            return this;
        }

        public virtual void Patch(dataModel.Currency target)
        {
            target.Code = Code;
            target.Name = Name;
            target.IsPrimary = IsPrimary;
            target.ExchangeRate = ExchangeRate;
            target.Symbol = Symbol;
            target.CustomFormatting = CustomFormatting;           
        }

    }
}
