// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtoCommerce.CoreModule.Data.Repositories;

#nullable disable

namespace VirtoCommerce.CoreModule.Data.MySql.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    partial class CoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("VirtoCommerce.CoreModule.Data.Currency.CurrencyEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CustomFormatting")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<int>("DecimalDigits")
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<decimal>("ExchangeRate")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MidpointRounding")
                        .HasMaxLength(18)
                        .HasColumnType("varchar(18)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("RoundingType")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Symbol")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .HasDatabaseName("IX_Code");

                    b.ToTable("Currency", (string)null);
                });

            modelBuilder.Entity("VirtoCommerce.CoreModule.Data.Model.SequenceEntity", b =>
                {
                    b.Property<string>("ObjectType")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("ObjectType");

                    b.ToTable("Sequence", (string)null);
                });

            modelBuilder.Entity("VirtoCommerce.CoreModule.Data.Package.PackageTypeEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<decimal>("Height")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Length")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("MeasureUnit")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("varchar(254)");

                    b.Property<decimal>("Width")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("PackageType", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
