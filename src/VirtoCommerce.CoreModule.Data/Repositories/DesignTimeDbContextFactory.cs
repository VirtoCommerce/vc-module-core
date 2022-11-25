using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VirtoCommerce.CoreModule.Data.Repositories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoreDbContext>
    {
        public CoreDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CoreDbContext>();

            var databaseProvider = args.First();

            switch (databaseProvider)
            {
                case "PostgreSql":
                    builder.UseNpgsql("User ID=postgres;Password=password;Host=localhost;Port=5432;Database=virtocommerce;", x => x.MigrationsAssembly("VirtoCommerce.CoreModule.Data.PostgreSql"));
                    break;
                case "MySql":
                    builder.UseMySql("server=localhost;user=root;password=virto;database=VirtoCommerce3;", new MySqlServerVersion(new Version(5, 7)), x => x.MigrationsAssembly("VirtoCommerce.CoreModule.Data.MySql"));
                    break;
                case "SqlServer":
                    builder.UseSqlServer("Data Source=(local);Initial Catalog=VirtoCommerce3;Persist Security Info=True;User ID=virto;Password=virto;MultipleActiveResultSets=True;Connect Timeout=30");
                    break;
                default:
                    throw new Exception($"Could not find database provider {databaseProvider}. Please specify an argument. Ex: -Args MySql");
            }

            return new CoreDbContext(builder.Options);
        }
    }
}
