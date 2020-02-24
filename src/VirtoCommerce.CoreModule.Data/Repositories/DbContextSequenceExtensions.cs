using System.Data;
using Microsoft.EntityFrameworkCore;

namespace VirtoCommerce.CoreModule.Data.Repositories
{
    static class DbContextSequenceExtensions
    {
        private static object DbContextLock = new object();

        public static void ResetSequence(this DbContext dbContext, string name, int startWith)
        {
        }

        public static void ResetSequence(this DbContext dbContext, string name, bool doResetStartWith, int startWith, int incrementBy)
        {
            lock (DbContextLock)
            {
                var sequenceRestartScript = doResetStartWith ? $"RESTART WITH {startWith}" : string.Empty;
                using var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = @$"IF EXISTS
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.[{name}]') AND type = 'SO')
ALTER SEQUENCE dbo.[{name}] {sequenceRestartScript} INCREMENT BY {incrementBy}
ELSE
CREATE SEQUENCE dbo.[{name}] AS INT START WITH {startWith} INCREMENT BY {incrementBy} CACHE 10";

                command.CommandType = CommandType.Text;
                dbContext.Database.OpenConnection();

                command.ExecuteNonQuery();

                dbContext.Database.CloseConnection();
            }
        }

        public static int GetNextSequenceValue(this DbContext dbContext, string name)
        {
            int result;

            lock (DbContextLock)
            {
                using var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = @$"IF NOT EXISTS
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.[{name}]') AND type = 'SO')
CREATE SEQUENCE dbo.[{name}] AS INT START WITH 1 INCREMENT BY 1 CACHE 10;
SELECT NEXT VALUE FOR dbo.[{name}]";
                command.CommandType = CommandType.Text;

                dbContext.Database.OpenConnection();

                result = (int)command.ExecuteScalar();

                dbContext.Database.CloseConnection();
            }

            return result;
        }
    }
}
