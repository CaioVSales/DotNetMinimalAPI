using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetMinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMovieRoomRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Rooms_RoomId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Movies",
                type: "int",
                nullable: true, // Change to nullable: true
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Rooms_RoomId",
                table: "Movies",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Rooms_RoomId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Rooms_RoomId",
                table: "Movies",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
        }
    }
}
