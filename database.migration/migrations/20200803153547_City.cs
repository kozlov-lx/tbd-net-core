namespace database.migration.Migrations
{
    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class City : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            MigrationAttribute migration = this.GetType().GetCustomAttribute<MigrationAttribute>()
                ?? throw new InvalidOperationException();

            string sql = File.ReadAllText($"migrations/{migration.Id}.sql");
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}