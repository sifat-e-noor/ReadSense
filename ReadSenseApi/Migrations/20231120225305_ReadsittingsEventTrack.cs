using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadSenseApi.Migrations
{
    /// <inheritdoc />
    public partial class ReadsittingsEventTrack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Settings",
                table: "ReadSettingsEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadSettings",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScrollingEvents_ReadSettingsEventId",
                table: "ScrollingEvents",
                column: "ReadSettingsEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScrollingEvents_ReadSettingsEvents_ReadSettingsEventId",
                table: "ScrollingEvents",
                column: "ReadSettingsEventId",
                principalTable: "ReadSettingsEvents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScrollingEvents_ReadSettingsEvents_ReadSettingsEventId",
                table: "ScrollingEvents");

            migrationBuilder.DropIndex(
                name: "IX_ScrollingEvents_ReadSettingsEventId",
                table: "ScrollingEvents");

            migrationBuilder.DropColumn(
                name: "Settings",
                table: "ReadSettingsEvents");

            migrationBuilder.DropColumn(
                name: "ReadSettings",
                table: "Devices");
        }
    }
}
