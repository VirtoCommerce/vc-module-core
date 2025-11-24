using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VirtoCommerce.CoreModule.Data.Currency;
using VirtoCommerce.CoreModule.Data.Model;
using VirtoCommerce.CoreModule.Data.Package;
using VirtoCommerce.Platform.Data.Infrastructure;

namespace VirtoCommerce.CoreModule.Data.Repositories
{
#pragma warning disable S109
    public class CoreDbContext : DbContextBase
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        protected CoreDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SequenceEntity>().ToTable("Sequence").HasKey(x => x.ObjectType);

            modelBuilder.Entity<CurrencyEntity>().ToTable("Currency").HasKey(x => x.Id);
            modelBuilder.Entity<CurrencyEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            modelBuilder.Entity<CurrencyEntity>().HasIndex(x => x.Code).HasDatabaseName("IX_Code");
            modelBuilder.Entity<CurrencyEntity>().Property(x => x.DecimalDigits).HasDefaultValue(2);

            modelBuilder.Entity<PackageTypeEntity>().ToTable("PackageType").HasKey(x => x.Id);
            modelBuilder.Entity<PackageTypeEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            modelBuilder.Entity<PackageTypeEntity>().Property(x => x.Height).HasPrecision(18, 4);
            modelBuilder.Entity<PackageTypeEntity>().Property(x => x.Length).HasPrecision(18, 4);
            modelBuilder.Entity<PackageTypeEntity>().Property(x => x.Width).HasPrecision(18, 4);

            base.OnModelCreating(modelBuilder);

            // Allows configuration for an entity type for different database types.
            // Applies configuration from all <see cref="IEntityTypeConfiguration{TEntity}" in VirtoCommerce.CoreModule.Data.XXX project. /> 
            switch (this.Database.ProviderName)
            {
                case "Pomelo.EntityFrameworkCore.MySql":
                    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("VirtoCommerce.CoreModule.Data.MySql"));
                    break;
                case "Npgsql.EntityFrameworkCore.PostgreSQL":
                    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("VirtoCommerce.CoreModule.Data.PostgreSql"));
                    break;
                case "Microsoft.EntityFrameworkCore.SqlServer":
                    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("VirtoCommerce.CoreModule.Data.SqlServer"));
                    break;
            }
        }
    }
#pragma warning restore S109
}
