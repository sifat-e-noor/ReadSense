using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadSenseApi.Migrations
{
    /// <inheritdoc />
    public partial class ReadSettingsEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReadSettingsEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    EnvironmentId = table.Column<int>(type: "int", nullable: false),
                    TimeOfChange = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FontSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fonts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineHeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineSpacing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Align = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Layout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadSettingsEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadSettingsEvents_Environments_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReadSettingsEvents_EnvironmentId",
                table: "ReadSettingsEvents",
                column: "EnvironmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadSettingsEvents");
        }
    }
}
