using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NisanKurumsalSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class KategoriUrun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 10, 12, 14, 31, 4, 801, DateTimeKind.Local).AddTicks(6520));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 9, 28, 11, 32, 12, 315, DateTimeKind.Local).AddTicks(5007));
        }
    }
}
