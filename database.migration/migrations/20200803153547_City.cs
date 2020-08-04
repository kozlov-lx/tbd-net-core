namespace tbd.database.migration.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class City : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            this.Sql(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}