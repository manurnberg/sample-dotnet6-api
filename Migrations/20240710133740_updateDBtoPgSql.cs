using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace sample_rest_api.Migrations
{
    public partial class updateDBtoPgSql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"Price\" TYPE numeric USING (\"Price\"::numeric);");

            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"CreatedAt\" TYPE timestamp with time zone USING (\"CreatedAt\"::timestamp with time zone);");

            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"Name\" TYPE text;");

            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"CategoryId\" TYPE integer;");

            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"Available\" TYPE boolean USING (\"Available\"::boolean);");

            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"Id\" TYPE integer;");

            migrationBuilder.Sql("ALTER TABLE \"Categories\" ALTER COLUMN \"Name\" TYPE text;");

            migrationBuilder.Sql("ALTER TABLE \"Categories\" ALTER COLUMN \"Id\" TYPE integer;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"Price\" TYPE text;");

            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"CreatedAt\" TYPE text;");

            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"Name\" TYPE text;");

            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"CategoryId\" TYPE integer;");

            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"Available\" TYPE integer;");

            migrationBuilder.Sql("ALTER TABLE \"Productos\" ALTER COLUMN \"Id\" TYPE integer;");

            migrationBuilder.Sql("ALTER TABLE \"Categories\" ALTER COLUMN \"Name\" TYPE text;");

            migrationBuilder.Sql("ALTER TABLE \"Categories\" ALTER COLUMN \"Id\" TYPE integer;");
        }
    }
}
