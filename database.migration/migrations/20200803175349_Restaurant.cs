﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace database.migration.Migrations
{
    public partial class Restaurant : Migration
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
