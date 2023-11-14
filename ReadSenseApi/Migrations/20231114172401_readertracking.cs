using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReadSenseApi.Migrations
{
    /// <inheritdoc />
    public partial class readertracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeOfDay",
                table: "Environments",
                newName: "Location");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContentUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScrollingEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    EnvironmentId = table.Column<int>(type: "int", nullable: false),
                    ReadSettingsEventId = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    StartPosition = table.Column<float>(type: "real", nullable: false),
                    EndPosition = table.Column<float>(type: "real", nullable: false),
                    StartTime = table.Column<long>(type: "bigint", nullable: false),
                    EndTime = table.Column<long>(type: "bigint", nullable: false),
                    StartPTagIndex = table.Column<int>(type: "int", nullable: true),
                    EndPTagIndex = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrollingEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReadingHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    PTagIndex = table.Column<int>(type: "int", nullable: false),
                    Inserted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingHistories_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadingHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ContentUrl", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Antoine de Saint-Exupéry", "/books/TheLittlePrince.html", "/images/TheLittlePrince.jpg", "The Little Prince" },
                    { 2, "PAULO COELHO", "/books/Alchemist.html", "/images/alchemist.jpg", "The Alchemist" },
                    { 3, "F. Scott Fitzgerald", "/books/TheGreatGatsby.html", "/images/TheGreatGatsBY.jpg", "The Great Gatsby" },
                    { 4, "J. D. Salinger", "/books/TheCatcherInTheRye.html", "/images/The_Catcher_in_the_Rye.jpg", "The Catcher in the Rye" },
                    { 5, "Tetsuko Kuroyanagi", "/books/TottoChan.html", "/images/Totto-Chan.jpg", "Totto-Chan: The Little Girl at the Window" },
                    { 6, "George Orwell", "/books/1984.html", "/images/1984.jpg", "1948" },
                    { 7, "Louisa May Alcott", "/books/LittleWoman.html", "/images/LittleWomen.jpg", "LITTLE WOMEN" },
                    { 8, "Charles Dickens", "/books/GreatExpectations.html", "/images/GreatExpectations.jpg", "Great Expectations" },
                    { 9, "John Steinbeck", "/books/OfMiceandMen.html", "/images/OfMiceandMen.jpg", "Of Mice and Men" },
                    { 10, "Jhumpa Lahiri", "/books/InterpreterofMaladies.html", "/images/InterpreterofMaladies.jpg", "Interpreter of Maladies" },
                    { 11, "Daniel Defoe", "/books/RobinsonCrusoe.html", "/images/RobinsonCrusoe.jpg", "Robinson Crusoe" },
                    { 12, "Jonathan Swift", "/books/GulivarsTravel.html", "/images/Gulliverstravel.jpg", "Gulliver's Travels" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReadingHistories_BookId",
                table: "ReadingHistories",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingHistories_UserId_BookId",
                table: "ReadingHistories",
                columns: new[] { "UserId", "BookId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadingHistories");

            migrationBuilder.DropTable(
                name: "ScrollingEvents");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Environments",
                newName: "TimeOfDay");
        }
    }
}
