using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addedUrlColumnToEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EntryComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 12, 17, 47, 30, 973, DateTimeKind.Local).AddTicks(1714),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 9, 13, 46, 27, 814, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 12, 17, 47, 30, 974, DateTimeKind.Local).AddTicks(1703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 9, 13, 46, 27, 814, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Entries",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Entries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EntryComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 9, 13, 46, 27, 814, DateTimeKind.Local).AddTicks(922),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 12, 17, 47, 30, 973, DateTimeKind.Local).AddTicks(1714));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 9, 13, 46, 27, 814, DateTimeKind.Local).AddTicks(7992),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 12, 17, 47, 30, 974, DateTimeKind.Local).AddTicks(1703));
        }
    }
}
