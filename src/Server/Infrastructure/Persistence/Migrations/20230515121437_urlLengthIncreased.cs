using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class urlLengthIncreased : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EntryComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 15, 14, 36, 862, DateTimeKind.Local).AddTicks(9383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 15, 15, 2, 24, 176, DateTimeKind.Local).AddTicks(2932));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Entries",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 15, 14, 36, 863, DateTimeKind.Local).AddTicks(6886),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 15, 15, 2, 24, 177, DateTimeKind.Local).AddTicks(424));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EntryComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 15, 2, 24, 176, DateTimeKind.Local).AddTicks(2932),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 15, 15, 14, 36, 862, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Entries",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Entries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 15, 15, 2, 24, 177, DateTimeKind.Local).AddTicks(424),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 15, 15, 14, 36, 863, DateTimeKind.Local).AddTicks(6886));
        }
    }
}
