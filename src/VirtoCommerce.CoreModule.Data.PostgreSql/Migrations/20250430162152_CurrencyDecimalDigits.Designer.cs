// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VirtoCommerce.CoreModule.Data.Repositories;

#nullable disable

namespace VirtoCommerce.CoreModule.Data.PostgreSql.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20250430162152_CurrencyDecimalDigits")]
    partial class CurrencyDecimalDigits
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VirtoCommerce.CoreModule.Data.Currency.CurrencyEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomFormatting")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("DecimalDigits")
                        .HasColumnType("integer")
                        .HasDefaultValue(2);

                    b.Property<decimal>("ExchangeRate")
                        .HasColumnType("Money");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("boolean");

                    b.Property<string>("MidpointRounding")
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("RoundingType")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("Symbol")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .HasDatabaseName("IX_Code");

                    b.ToTable("Currency", (string)null);
                });

            modelBuilder.Entity("VirtoCommerce.CoreModule.Data.Model.SequenceEntity", b =>
                {
                    b.Property<string>("ObjectType")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("ObjectType");

                    b.ToTable("Sequence", (string)null);
                });

            modelBuilder.Entity("VirtoCommerce.CoreModule.Data.Package.PackageTypeEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<decimal>("Height")
                        .HasPrecision(18, 4)
                        .HasColumnType("numeric(18,4)");

                    b.Property<decimal>("Length")
                        .HasPrecision(18, 4)
                        .HasColumnType("numeric(18,4)");

                    b.Property<string>("MeasureUnit")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)");

                    b.Property<decimal>("Width")
                        .HasPrecision(18, 4)
                        .HasColumnType("numeric(18,4)");

                    b.HasKey("Id");

                    b.ToTable("PackageType", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
