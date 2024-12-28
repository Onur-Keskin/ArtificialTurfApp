using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_FootballFields_FootballFieldId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_FootballFields_FootballFieldId",
                table: "Reservations",
                column: "FootballFieldId",
                principalTable: "FootballFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_FootballFields_FootballFieldId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_FootballFields_FootballFieldId",
                table: "Reservations",
                column: "FootballFieldId",
                principalTable: "FootballFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
