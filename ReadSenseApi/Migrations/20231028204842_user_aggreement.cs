using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadSenseApi.Migrations
{
    /// <inheritdoc />
    public partial class user_aggreement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AgreementSigned",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreementSigned",
                table: "Users");
        }
    }
}
