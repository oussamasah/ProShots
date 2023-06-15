using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProShots.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dislike",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "like",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6593));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6596));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 11, 1, 27, 207, DateTimeKind.Local).AddTicks(6602));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dislike",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "like",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(866));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(878));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(879));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(879));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(884));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(923));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 13, 10, 45, 32, 521, DateTimeKind.Local).AddTicks(923));
        }
    }
}
