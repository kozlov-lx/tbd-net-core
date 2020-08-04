namespace tbd.database.migration
{
    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.EntityFrameworkCore.Migrations;

    public static class MigrationExtensions
    {
        public static void Sql(this Migration migration, MigrationBuilder migrationBuilder)
        {
            if (migration == null)
            {
                throw new ArgumentNullException(nameof(migration));
            }

            MigrationAttribute attr = migration.GetType().GetCustomAttribute<MigrationAttribute>()
                ?? throw new InvalidOperationException();

            string sql = File.ReadAllText($"migrations/{attr.Id}.sql");
            migrationBuilder.Sql(sql);
        }
    }
}