using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadSenseApi.Migrations
{
    /// <inheritdoc />
    public partial class ReadSettingsEventUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Inserted",
                table: "ReadSettingsEvents",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastUpdated",
                table: "ReadSettingsEvents",
                type: "datetimeoffset",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "ReadSettingsEvents");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "ReadSettingsEvents");
        }
    }
}
