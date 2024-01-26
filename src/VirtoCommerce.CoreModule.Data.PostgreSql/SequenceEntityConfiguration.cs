using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtoCommerce.CoreModule.Data.Model;

namespace VirtoCommerce.CoreModule.Data.PostgreSql
{
    public class SequenceEntityConfiguration : IEntityTypeConfiguration<SequenceEntity>
    {
        public void Configure(EntityTypeBuilder<SequenceEntity> builder)
        {
            var converter = new ValueConverter<byte[], long>(
                v => BitConverter.ToInt64(v, 0),
                v => BitConverter.GetBytes(v));

            builder.Property(c => c.RowVersion)
                .HasColumnType("xid")
                .HasColumnName("xmin")
                .HasConversion(converter)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();
        }
    }
}
