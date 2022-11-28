using Microsoft.EntityFrameworkCore;

namespace VirtoCommerce.CoreModule.Data.PostgreSql
{
    public static class DbContextOptionsBuilderExtensions
    {
        /// <summary>
        /// Configures the context to use PostgreSql.
        /// </summary>
        public static DbContextOptionsBuilder UsePostgreSql(this DbContextOptionsBuilder builder, string connectionString) =>
            builder.UseNpgsql(connectionString, db => db
                .MigrationsAssembly(typeof(PostgreSqlDbContextFactory).Assembly.GetName().Name));
    }
}
