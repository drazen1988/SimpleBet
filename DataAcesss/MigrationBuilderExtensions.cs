using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAcesss
{
    public static class MigrationBuilderExtensions
    {
        public static OperationBuilder<SqlOperation> CreateProcedures(this MigrationBuilder migrationBuilder)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SQL\Create\StoredProceduresCreateAll.sql");
            string sql = File.ReadAllText(path);

            return migrationBuilder.Sql(sql);
        }

        public static OperationBuilder<SqlOperation> CreateTriggers(this MigrationBuilder migrationBuilder)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SQL\Create\TriggersCreateAll.sql");
            string sql = File.ReadAllText(path);

            return migrationBuilder.Sql(sql);
        }

        public static OperationBuilder<SqlOperation> DropProcedures(this MigrationBuilder migrationBuilder)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SQL\Drop\StoredProceduresDropAll.sql");
            string sql = File.ReadAllText(path);

            return migrationBuilder.Sql(sql);
        }

        public static OperationBuilder<SqlOperation> DropTriggers(this MigrationBuilder migrationBuilder)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SQL\Drop\TriggersDropAll.sql");
            string sql = File.ReadAllText(path);

            return migrationBuilder.Sql(sql);
        }
    }
}
