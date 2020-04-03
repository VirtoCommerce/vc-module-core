using System;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace VirtoCommerce.CoreModule.Data.Repositories
{
    static class DbContextSequenceExtensions
    {
        private static object DbContextLock = new object();

        public static void ResetSequenceForDescriptor(this DbContext dbContext, string descriptorId, DateTime? resetDate)
        {
            lock (DbContextLock)
            {
                using var command = dbContext.Database.GetDbConnection().CreateCommand();
                // TODO: Add command that checks whether lastReseDate date part is lesser than reseDate, and if so, resets the sequence with the starts value from descriptor
                //@$"DECLARE @LastResetDate AS DATETIME;
                //DECLARE @StartWith as BIGINT;
                //DECLARE @SequenceName as nvarchar(64);
                //SELECT @LastResetDate = [LastResetDate], @StartWith = [StartsWith], @SequenceName = [Template]
                //  FROM [dbo].[NumberGeneratorDescriptor]
                //  WHERE [Id] = '@Id';
                //IF CAST(@LastResetDate as DATE) < CAST('' AS DATE)
                //	IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.['+ @SequenceName +']') AND type = 'SO')
                //		ALTER SEQUENCE dbo.[@SequenceName] RESTART WITH @StartWith";
                // Something like this, but need to rework last row, as it is not possible to directly use string var as name of the object
                command.CommandText = "";

                command.CommandType = CommandType.Text;
                dbContext.Database.OpenConnection();

                command.ExecuteNonQueryAsync();

                dbContext.Database.CloseConnection();
            }
        }

        public static void CreateOrUpdateSequence(this DbContext dbContext, string name, long startWith, int incrementBy)
        {
            lock (DbContextLock)
            {
                using var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = @$"IF EXISTS
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.[{name}]') AND type = 'SO')
ALTER SEQUENCE dbo.[{name}] RESTART WITH {startWith} INCREMENT BY {incrementBy}
ELSE
CREATE SEQUENCE dbo.[{name}] AS BIGINT START WITH {startWith} INCREMENT BY {incrementBy} CACHE 10";

                command.CommandType = CommandType.Text;
                dbContext.Database.OpenConnection();

                command.ExecuteNonQueryAsync();

                dbContext.Database.CloseConnection();
            }
        }

        public static long GetNextSequenceValue(this DbContext dbContext, string name)
        {
            long result;

            lock (DbContextLock)
            {
                using var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = @$"IF NOT EXISTS
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.[{name}]') AND type = 'SO')
CREATE SEQUENCE dbo.[{name}] AS BIGINT START WITH 1 INCREMENT BY 1 CACHE 10;
SELECT NEXT VALUE FOR dbo.[{name}]";
                command.CommandType = CommandType.Text;

                dbContext.Database.OpenConnection();

                result = (long)command.ExecuteScalar();

                dbContext.Database.CloseConnection();
            }

            return result;
        }

        public static void DeleteSequence(this DbContext dbContext, string name)
        {
            lock (DbContextLock)
            {
                using var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = $@"DROP SEQUENCE IF EXISTS dbo.[{name}]";

                command.CommandType = CommandType.Text;
                dbContext.Database.OpenConnection();

                command.ExecuteNonQuery();

                dbContext.Database.CloseConnection();
            }
        }
    }
}
