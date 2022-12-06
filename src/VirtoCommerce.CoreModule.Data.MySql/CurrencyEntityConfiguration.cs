using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtoCommerce.CoreModule.Data.Currency;

namespace VirtoCommerce.CoreModule.Data.MySql
{
    public class CurrencyEntityConfiguration : IEntityTypeConfiguration<CurrencyEntity>
    {
        public void Configure(EntityTypeBuilder<CurrencyEntity> builder)
        {
            builder.Property(x => x.ExchangeRate).HasColumnType("decimal").HasPrecision(18, 4);
        }
    }
}
